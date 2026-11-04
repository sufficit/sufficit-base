# DID testing contracts

`Sufficit.Telephony.DIDs.Testing`: contracts of the DID testing system and `DIDTestRules`, the validation shared by API, worker and screen. It decides what can reach `DID_TEST_CLIS`, the PBX list compared with every inbound caller: at least 10 digits, a DID of the Sufficit context, suffixes of 10 digits joined by `|`. System overview: `sufficit-fastagi-service/docs/USAGE-DID-TESTING.md`.
