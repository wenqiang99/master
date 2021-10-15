using Abp.Configuration;
using Abp.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPractice.FileInfos
{
    public class FileSettingProvider : SettingProvider
    {
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new[]
            {
                new SettingDefinition(FileSettingNames.DefaultFileType, "", L("DefaultFileType"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                new SettingDefinition(FileSettingNames.DefaultFileSize, "", L("DefaultFileSize"), scopes: SettingScopes.Application | SettingScopes.Tenant),
                new SettingDefinition(FileSettingNames.DefaultFilePath, "", L("DefaultFilePath"), scopes: SettingScopes.Application | SettingScopes.Tenant),
            };
        }
        private static LocalizableString L(string name)
        {
            return new LocalizableString(name, MyPracticeConsts.LocalizationSourceName);
        }
    }
}
