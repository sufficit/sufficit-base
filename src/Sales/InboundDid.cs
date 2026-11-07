using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Sufficit.Sales;

/// <summary>Structured inbound number. Extra remains historical/free-text evidence, not the authoritative identity.</summary>
public static class InboundDid
{
    public const string Key = "did";
    public static bool Applies(Contract contract) => contract.ParameterValues.ContainsKey(Key) || (contract.Title == Constants.SERVICE_TRUNK_INBOUND || (contract.Title ?? "").StartsWith(Constants.SERVICE_TRUNK_INBOUND + " ", StringComparison.Ordinal));
    public static string Normalize(string value)
    {
        var text = (value ?? "").Trim();
        if (!Regex.IsMatch(text, @"^\+?[0-9 ()-]+$"))
            throw new ArgumentException("Informe um DID completo, com DDD e número.");
        var digits = new string(text.Where(c => c >= '0' && c <= '9').ToArray());
        // Internal carrier DIDs can be opaque, leading-zero identifiers. Preserve them exactly.
        if (text == digits && Regex.IsMatch(digits, @"^00[0-9]{6,13}$")) return digits;
        if (digits.StartsWith("550800", StringComparison.Ordinal)) digits = "55" + digits.Substring(3);
        else if (digits.StartsWith("0800", StringComparison.Ordinal)) digits = "55" + digits.Substring(1);
        else if (digits.Length == 10 || digits.Length == 11) digits = "55" + digits;
        if (!Regex.IsMatch(digits, @"^55(?:800[0-9]{7}|[1-9][0-9][2-9][0-9]{7,8})$"))
            throw new ArgumentException("DID inválido: use DDD e número completos ou 0800 completo.");
        return digits;
    }
    public static string? Read(Contract contract)
        => contract.ParameterValues.TryGetValue(Key, out var value) && !string.IsNullOrWhiteSpace(value) ? Normalize(value) : null;

    /// <summary>Migration only: require an unambiguous whole field and agreement between key and Extra.</summary>
    public static string? HistoricalCandidate(Contract contract)
    {
        string? From(string? value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            value = Regex.Replace(value.Trim(), @"^(?:DID|WHAT|WHATSAPP)\s*:\s*", "", RegexOptions.IgnoreCase);
            try { return Normalize(value); } catch (ArgumentException) { return null; }
        }
        var key = From(contract.Key); var extra = From(contract.Extra);
        if (key != null && extra != null && key != extra) return null;
        return key ?? extra;
    }
    public static bool SameReference(Contract left, Contract right)
    {
        if (!Applies(left) || !Applies(right)) return left.Extra == right.Extra;
        var a = Read(left) ?? HistoricalCandidate(left); var b = Read(right) ?? HistoricalCandidate(right);
        if (a != null || b != null) return a != null && a == b && IsWhatsApp(left) == IsWhatsApp(right);
        return left.Extra == right.Extra; // Existing unstructured historical evidence remains exact-only.
    }
    public static bool IsWhatsApp(Contract contract)
        => contract.ParameterValues.TryGetValue("inbound_kind", out var kind) ? kind == "whatsapp"
            : Regex.IsMatch(contract.Extra ?? "", @"^\s*(?:WHAT|WHATSAPP)\s*:", RegexOptions.IgnoreCase);
    public static string? TechnicalReference(Contract contract)
    {
        if (!Applies(contract)) return contract.Extra;
        var did = Read(contract);
        return did == null ? contract.Extra : (IsWhatsApp(contract) ? "WHAT: " : "DID: ") + did;
    }
    public static void Require(Contract contract)
    {
        var did = Read(contract) ?? throw new ArgumentException("O parâmetro did é obrigatório para o tronco de entrada.");
        contract.ParameterValues[Key] = did;
    }
}
