using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using uSync.Migrations.Core.Context;
using uSync.Migrations.Core.Extensions;
using uSync.Migrations.Core.Migrators;
using uSync.Migrations.Core.Migrators.Models;

namespace MyMigrations;

[SyncMigrator("UmbracoForms.FormPicker")]
[SyncMigratorVersion(7, 8)]
public class MyUmbracoFormsMigrator : SyncPropertyMigratorBase
{
    
    public override object? GetConfigValues(SyncMigrationDataTypeProperty dataTypeProperty, SyncMigrationContext context)
    {
        return dataTypeProperty.PreValues.ConvertPreValuesToJson(true);
    }

    public override string? GetContentValue(SyncMigrationContentProperty contentProperty, SyncMigrationContext context)
    {
        try
        {
            var data = JsonConvert.DeserializeObject<UmbracoFormsFormPickerModel>(contentProperty.Value);
            return data.macroParamsDictionary.FormGuid;
        }
        catch
        {
           return contentProperty.Value;
        }
    }
}

public class UmbracoFormsFormPicker
{
    public string FormGuid { get; set; }
    public string FormTheme { get; set; }
    public string ExcludeScripts { get; set; }
}

public class UmbracoFormsFormPickerModel
{
    public string macroAlias { get; set; }
    public UmbracoFormsFormPicker macroParamsDictionary { get; set; }
}
