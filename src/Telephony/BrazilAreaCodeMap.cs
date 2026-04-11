using System;
using System.Collections.Generic;
using System.Linq;

namespace Sufficit.Telefonia.Classifier
{
    /// <summary>
    /// Immutable metadata for a Brazilian federative unit and its supported area codes.
    /// </summary>
    public sealed class BrazilAreaCodeInfo
    {
        public BrazilAreaCodeInfo(
            RegionsOfBrazil region,
            string uf,
            string stateName,
            double latitude,
            double longitude,
            params string[] areaCodes)
        {
            if (string.IsNullOrWhiteSpace(uf))
                throw new ArgumentException("UF is required.", nameof(uf));

            if (string.IsNullOrWhiteSpace(stateName))
                throw new ArgumentException("State name is required.", nameof(stateName));

            if (areaCodes == null || areaCodes.Length == 0)
                throw new ArgumentException("At least one area code is required.", nameof(areaCodes));

            Region = region;
            UF = uf.Trim().ToUpperInvariant();
            StateName = stateName.Trim();
            Latitude = latitude;
            Longitude = longitude;
            AreaCodes = Array.AsReadOnly(areaCodes
                .Where(static s => !string.IsNullOrWhiteSpace(s))
                .Select(static s => s.Trim())
                .Distinct(StringComparer.Ordinal)
                .ToArray());

            if (AreaCodes.Count == 0)
                throw new ArgumentException("At least one valid area code is required.", nameof(areaCodes));

            CanonicalAreaCode = AreaCodes[0];
        }

        public RegionsOfBrazil Region { get; }

        public string UF { get; }

        public string StateName { get; }

        public double Latitude { get; }

        public double Longitude { get; }

        public string CanonicalAreaCode { get; }

        public IReadOnlyList<string> AreaCodes { get; }
    }

    /// <summary>
    /// Centralized lookup for mapping Brazilian DDDs and phone numbers to federative units.
    /// </summary>
    public static class BrazilAreaCodeMap
    {
        private static readonly BrazilAreaCodeInfo[] _all =
        {
            new BrazilAreaCodeInfo(RegionsOfBrazil.ACRE, "AC", "Acre", -9.97499d, -67.82430d, "68"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.ALAGOAS, "AL", "Alagoas", -9.64985d, -35.70890d, "82"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.AMAPA, "AP", "Amapa", 0.03493d, -51.06940d, "96"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.AMAZONAS, "AM", "Amazonas", -3.11903d, -60.02170d, "92", "97"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.BAHIA, "BA", "Bahia", -12.97140d, -38.50140d, "71", "73", "74", "75", "77"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.CEARA, "CE", "Ceara", -3.73186d, -38.52670d, "85", "88"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.DISTRITO_FEDERAL, "DF", "Distrito Federal", -15.79390d, -47.88280d, "61"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.ESPIRITO_SANTO, "ES", "Espirito Santo", -20.31550d, -40.31280d, "27", "28"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.GOIAS, "GO", "Goias", -16.68690d, -49.26480d, "62", "64"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.MARANHAO, "MA", "Maranhao", -2.53073d, -44.30680d, "98", "99"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.MATO_GROSSO, "MT", "Mato Grosso", -15.60140d, -56.09790d, "65", "66"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.MATO_GROSSO_DO_SUL, "MS", "Mato Grosso do Sul", -20.46970d, -54.62010d, "67"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.MINAS_GERAIS, "MG", "Minas Gerais", -19.91670d, -43.93450d, "31", "32", "33", "34", "35", "37", "38"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.PARA, "PA", "Para", -1.45583d, -48.49020d, "91", "93", "94"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.PARAIBA, "PB", "Paraiba", -7.11950d, -34.84500d, "83"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.PARANA, "PR", "Parana", -25.42840d, -49.27330d, "41", "42", "43", "44", "45", "46"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.PERNAMBUCO, "PE", "Pernambuco", -8.04760d, -34.87700d, "81", "87"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.PIAUI, "PI", "Piaui", -5.08921d, -42.80160d, "86", "89"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.RIO_DE_JANEIRO, "RJ", "Rio de Janeiro", -22.90680d, -43.17290d, "21", "22", "24"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.RIO_GRANDE_DO_NORTE, "RN", "Rio Grande do Norte", -5.79448d, -35.21100d, "84"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.RIO_GRANDE_DO_SUL, "RS", "Rio Grande do Sul", -30.03460d, -51.21770d, "51", "53", "54", "55"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.RONDONIA, "RO", "Rondonia", -8.76077d, -63.89990d, "69"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.RORAIMA, "RR", "Roraima", 2.82384d, -60.67530d, "95"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.SANTA_CATARINA, "SC", "Santa Catarina", -27.59490d, -48.54820d, "47", "48", "49"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.SAO_PAULO, "SP", "Sao Paulo", -23.55050d, -46.63330d, "11", "12", "13", "14", "15", "16", "17", "18", "19"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.SERGIPE, "SE", "Sergipe", -10.94720d, -37.07310d, "79"),
            new BrazilAreaCodeInfo(RegionsOfBrazil.TOCANTINS, "TO", "Tocantins", -10.18400d, -48.33360d, "63"),
        };

        private static readonly IReadOnlyDictionary<string, BrazilAreaCodeInfo> _byAreaCode =
            BuildByAreaCode();

        private static readonly IReadOnlyDictionary<string, BrazilAreaCodeInfo> _byUf =
            _all.ToDictionary(static item => item.UF, static item => item, StringComparer.OrdinalIgnoreCase);

        private static readonly IReadOnlyDictionary<RegionsOfBrazil, BrazilAreaCodeInfo> _byRegion =
            _all.ToDictionary(static item => item.Region, static item => item);

        public static IReadOnlyList<BrazilAreaCodeInfo> All => Array.AsReadOnly(_all);

        public static bool TryGetByRegion(RegionsOfBrazil region, out BrazilAreaCodeInfo? info)
            => _byRegion.TryGetValue(region, out info);

        public static bool TryGetByUf(string? uf, out BrazilAreaCodeInfo? info)
        {
            info = null;

            if (string.IsNullOrWhiteSpace(uf))
                return false;

            return _byUf.TryGetValue(uf.Trim(), out info);
        }

        public static bool TryGetByAreaCode(string? areaCode, out BrazilAreaCodeInfo? info)
        {
            info = null;

            if (NormalizeAreaCode(areaCode) is not string normalized)
                return false;

            return _byAreaCode.TryGetValue(normalized, out info);
        }

        public static bool TryGetByPhoneNumber(string? phoneNumber, out BrazilAreaCodeInfo? info)
        {
            info = null;

            if (TryExtractAreaCode(phoneNumber) is not string areaCode)
                return false;

            return TryGetByAreaCode(areaCode, out info);
        }

        public static string? TryExtractAreaCode(string? phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return null;

            var digits = new string(phoneNumber.Where(char.IsDigit).ToArray());
            if (digits.Length < 10)
                return null;

            if (digits.StartsWith("55", StringComparison.Ordinal) && digits.Length >= 12)
                return digits.Substring(2, 2);

            return digits.Substring(0, 2);
        }

        private static string? NormalizeAreaCode(string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return null;

            var digits = new string(value.Where(char.IsDigit).ToArray());
            return digits.Length == 2 ? digits : null;
        }

        private static IReadOnlyDictionary<string, BrazilAreaCodeInfo> BuildByAreaCode()
        {
            var map = new Dictionary<string, BrazilAreaCodeInfo>(StringComparer.Ordinal);

            foreach (var item in _all)
            {
                foreach (var areaCode in item.AreaCodes)
                {
                    map[areaCode] = item;
                }
            }

            return map;
        }
    }
}
