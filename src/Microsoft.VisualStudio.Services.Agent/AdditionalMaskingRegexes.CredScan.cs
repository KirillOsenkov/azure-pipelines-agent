// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.
//
// THIS FILE IS GENERATED CODE.
// DO NOT EDIT.
// YOUR EDITS MAY BE LOST.
//
// Generated by tools/CredScanRegexes/CredScanRegexes.csproj
// from CredScan version 1.3.30-client-012060001

using System.Collections.Generic;

namespace Microsoft.VisualStudio.Services.Agent
{
    internal static partial class AdditionalMaskingRegexes
    {
        public static IEnumerable<string> CredScanPatterns => credScanPatterns;

        // Each pattern or set of patterns has a comment mentioning
        // which CredScan policy it came from. In CredScan, if a pattern
        // contains a named group, then that named group is considered the
        // sensitive part.
        // 
        // For the agent, we don't want to mask the non-sensitive parts, so
        // we wrap lookbehind and lookahead non-match groups around those
        // parts which aren't in the named group.
        // 
        // The non-matching parts are pulled out into separate string
        // literals to make them easier to manually examine.
        private static IEnumerable<string> credScanPatterns =
            new List<string>()
            {
                // AnsibleVaultData
                  @"" // pre-match
                + @"\$ANSIBLE_VAULT;\d+\.\d+;AES256\s+\d+" // match
                + @"", // post-match

                // AzurePowerShellTokenCache
                  @"" // pre-match
                + @"[""']TokenCache[""']\s*:\s*\{\s*[""']CacheData[""']\s*:\s*[""'][a-z0-9/\+]{86}" // match
                + @"", // post-match

                // Base64EncodedStringLiteral
                  @"(?<=(^|[""'>;=\s#]))" // pre-match
                + @"(?<DataBlock>(?-i)MI(?i)[a-z0-9/+\s\u0085\u200b""',\\]{200,20000}[a-z0-9/+]={0,2})" // match
                + @"", // post-match

                // JsonWebToken
                  @"" // pre-match
                + @"(?-i)(?<JwtToken>eyJ(?i)[a-z0-9\-_%]+\.(?-i)eyJ(?i)[a-z0-9\-_%]+\.[a-z0-9\-_%]+)|([rR]efresh_?[tT]oken|REFRESH_?TOKEN)[""']?\s*[:=]{1,2}\s*[""']?(?<JwtToken>(\w+-)+\w+)[""']?" // match
                + @"", // post-match

                // SlackTokens
                  @"" // pre-match
                + @"xox[pbar]\-[a-z0-9\-]+" // match
                + @"", // post-match

                // SymmetricKey128
                  @"(?<=[^\w/\+\._\$,\\])" // pre-match
                + @"(?<SymmetricKey>[a-z0-9/\+]{22}==)" // match
                + @"(?=([^\w/\+\.\$]|$))", // post-match

                // SymmetricKey128Hex
                  @"(?<=[^\w/\+\._\$,\\][dapi]+)" // pre-match
                + @"(?<SymmetricKey>[a-f0-9]{32})" // match
                + @"(?=([^\w/\+\.\$]|$))", // post-match

                // SymmetricKey160Hex
                  @"(?<=[^\w/\+\._\$,\\])" // pre-match
                + @"(?<Hex160>[a-f0-9/\+]{40})" // match
                + @"(?=([^\w/\+\.\$]|$))", // post-match

                // SymmetricKey232
                  @"(?<=[^\w/\+\._\$,\\])" // pre-match
                + @"(?<SymmetricKey>(?-i)AIza(?i)[a-z0-9_\\\-]{35})" // match
                + @"(?=([^\w/\+\.\$]|$))", // post-match

                // SymmetricKey240
                  @"(?<=[^\w/\+\.\-\$,\\])" // pre-match
                + @"(?<SymmetricKey>[a-z0-9/\+]{40})" // match
                + @"(?=([^\w/\+\.\-\$,\\]|$))", // post-match

                // SymmetricKey256
                  @"(?<=[^\w/\+\.\$,\\])" // pre-match
                + @"(?<SymmetricKey>[a-z0-9/\+]{43}=)" // match
                + @"(?=([^\w/\+\.\$]|$))", // post-match

                // SymmetricKey256B32
                  @"(?<=[^\w/\+\._\-\$,\\])" // pre-match
                + @"(?<SymmetricKey>(?-i)[a-z2-7]{52}(?i))" // match
                + @"(?=(?<=[0-9]+[a-z]+[0-9]+.{0,49})([^\w/\+\.\-\$,]|$))", // post-match

                // SymmetricKey256UrlEncoded
                  @"(?<=[^\w/\+\._\-\$,\\%])" // pre-match
                + @"(?<SymmetricKey>[a-z0-9%]{43,63}%3d)" // match
                + @"", // post-match

                // SymmetricKey320
                  @"(?<=[^\w/\+\.\-\$,\\])" // pre-match
                + @"(?<SymmetricKey>[a-z0-9/\+]{54}={2})" // match
                + @"(?=([^\w/\+\.\-\$,\\]|$))", // post-match

                // SymmetricKey320UrlEncoded
                  @"(?<=[^\w/\+\.\-\$,\\%])" // pre-match
                + @"(?<SymmetricKey>[a-z0-9%]{54,74}(%3d){2})" // match
                + @"", // post-match

                // SymmetricKey360
                  @"(?<=[^\w/\+\.\-\$,\\])" // pre-match
                + @"(?<SymmetricKey>[a-z0-9/\+]{60})" // match
                + @"(?=[^\w/\+\.\-\$,\\])", // post-match

                // SymmetricKey512
                  @"(?<=[^\r\n\t\w/\+\.\-\$,\\])" // pre-match
                + @"(?<SymmetricKey>[a-z0-9/\+]{86}==)" // match
                + @"(?=([^\w/\+\.\-\$]|$))", // post-match

                // AzureActiveDirectoryLoginCredentials
                  @"(?<=@([a-z0-9.]+\.(on)?)?microsoft\.com[ -~\s\u200b]{1,80}?(userpass|password|pwd|pw|\wpass[ =:>]+|(get|make)securestring)\W)" // pre-match
                + @"(?<Password>[^\s;`,""'\(\)]{10,80})" // match
                + @"(?=[\s;`,""'\(\)])", // post-match

                // AzureActiveDirectoryLoginCredentials
                  @"" // pre-match
                + @"(?<MigrationPassword>(\-destinationPasswordPlain ""[^""]+?""))" // match
                + @"(?=[ -~\s\u200b]{1,150}?@([a-z0-9.]+\.(on)?)?microsoft\.com)", // post-match

                // AzureActiveDirectoryLoginCredentials
                  @"(?<=(sign_in|SharePointOnlineAuthenticatedContext|(User|Exchange)Credentials?|password)[ -~\s\u200b]{1,100}?@([a-z0-9.]+\.(on)?)?microsoft\.com['""]?( \|\| \w+)?\s*,[\s\u200b]['""]?)" // pre-match
                + @"(?<ArgumentPassword>[^`'""\s,;\(\)]+?)" // match
                + @"(?=[`'""\s,;\(\)])", // post-match

                // AzureActiveDirectoryLoginCredentials
                  @"" // pre-match
                + @"(?<PrevPassword>password[\W_][ -~\s\u200b]{40,100}?)" // match
                + @"(?=@([a-z0-9\.]+\.(on)?)?microsoft\.com)", // post-match

                // LoginCredentials
                  @"" // pre-match
                + @"[^a-z\$](DB_USER|user id|uid|(sql)?user(name)?|service\s?account)\s*[^\w\s,]([ -~\s\u200b]{2,120}?|[ -~]{2,30}?)([^a-z\s\$]|\s)\s*(DB_PASS|(sql|service)?password|pwd)\s*[^a-z,\+&\)\]\}\[\{_][ -~\s\u200b]{2,700}?([;|<,})]|$)|[^a-z\s\$]\s*(DB_PASS|password|pwd)\s*[^a-z,\+&\)\]\}\[\{_][ -~\s\u200b]{2,60}?[^a-z\$](DB_USER|user id|uid|user(name)?)\s*[^\w\s,]([ -~\s\u200b]{2,60}?|[ -~]{2,30}?)([;|<,})]|$)" // match
                + @"", // post-match

                // LoginCredentialsInUrl
                  @"(?<=(amqp|ssh|(ht|f)tps?)://[^%:\s""'/][^:\s""'/\$]+[^:\s""'/\$%]:)" // pre-match
                + @"(?<Password>[^%\s""'/][^@\s""'/]{0,100}[^%\s""'/])" // match
                + @"(?=@[\$a-z0-9:\.\-_%\?=/]+)", // post-match

                // CertificatePrivateKeyHeader
                  @"" // pre-match
                + @"(?-i)\-{5}BEGIN( ([DR]SA|EC|OPENSSH|PGP))? PRIVATE KEY( BLOCK)?\-{5}" // match
                + @"", // post-match

                // HttpAuthorizationHeader
                  @"(?<=authorization[,\[:= ""']+(basic|digest|hoba|mutual|negotiate|oauth( oauth_token=)?|bearer [^e""'&]|scram\-sha\-1|scram\-sha\-256|vapid|aws4\-hmac\-sha256)[\s\r\n]{0,10})" // pre-match
                + @"(?<Token>[a-z0-9/+_.=]{10,})" // match
                + @"", // post-match

                // ClientSecretContext
                  @"(?<=(^|[a-z\s""'_])((app(lication)?|client)[_\- ]?(key(url)?|secret)|refresh[_\-]?token|[^t]AccessToken(Secret)?|(Consumer|api)[_\- ]?(Secret|Key)|(Twilio(Account|Auth)[_\- ]?(Sid|Token)))([\s=:>]{1,10}|[\s""':=|>,]{3,15}|[""'=:\(]{2}))" // pre-match
                + @"(?<ClientSecret>(""data:text/plain,.+""|[a-z0-9/+=_.-]{10,200}[^\(\[\{;,\r\n]|[^\s""';<,\)]{5,200}))" // match
                + @"", // post-match

                // CommunityStringContext
                  @"(?<=(^|\W{2}|set )snmp(\-server)?( | [ -~]+? )(community|priv)\s[""']?)" // pre-match
                + @"(?<CommunityString>[^\s]+)" // match
                + @"(?=[""']?(\s|$))", // post-match

                // PasswordContextInScript
                  @"(?<=\s-(admin|user|vm)?password\s+[""']?)" // pre-match
                + @"(?<ScriptArgumentPassword>[^$\(\[<\{\-\s,""']+)[""']?(\s|$)" // match
                + @"", // post-match

                // PasswordContextInScript
                  @"(?<=certutil(\.exe)?.{1,10}\-p\s+[""']?)" // pre-match
                + @"(?<CertUtilPassword>[^\s,]{2,50})" // match
                + @"(?=[""']?)", // post-match

                // PasswordContextInScript
                  @"(?<=(^|[_\s\$])[a-z]*(password|secret(key)?)[ \t]*[=:]+[ \t]*)" // pre-match
                + @"(?<ScriptAssignmentPassword>[^:\s""';,<]{2,200})" // match
                + @"", // post-match

                // PasswordContextInScript
                  @"(?<=\s-Name\s+[""']\w+Password[""']\s+-Value\s+[""']?)" // pre-match
                + @"(?<RegistryPassword>[^\s""']{2,1100})" // match
                + @"(?=[""']?)", // post-match

                // PasswordContextInScript
                  @"(?<=(^|[\s\r\n\\])net(\.exe)?[""'\s\\]{1,5}(user\s+|share\s+/user:)[^\s,/]+[ \t]+[""']?)" // pre-match
                + @"(?<NetUsePassword>[^\s,""'>/]{2,50})" // match
                + @"(?=[""']?)", // post-match

                // PasswordContextInScript
                  @"(?<=psexec(\.exe)?.{1,50}-u.{1,50}-p\s+[""']?)" // pre-match
                + @"(?<PsExecPassword>[^\s,]{2,50})" // match
                + @"(?=[""']?)", // post-match

                // SymmetricKeyContextInXml
                  @"" // pre-match
                + @"<(machineKey|parameter name=""|[a-z]+AccountInfo[^a-z])" // match
                + @"", // post-match

            };
    }
}