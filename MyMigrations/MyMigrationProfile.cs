using uSync.Migrations.Core;
using uSync.Migrations.Core.Composing;
using uSync.Migrations.Core.Configuration.Models;

namespace MyMigrations;

/***** this code is not hooked up by default, it never runs *****/

/// <summary>
///  A Custom migration profile, to do things in special ways.
/// </summary>

public class MyMigrationProfile : ISyncMigrationPlan
{
    private readonly SyncMigrationHandlerCollection _migrationHandlers;

    public MyMigrationProfile(SyncMigrationHandlerCollection migrationHandlers)
    {
        _migrationHandlers = migrationHandlers;
    }

    public string Name => "My Migration: NestedContent, Grid and UmbracoForms.FormPicker";

    public string Icon => "icon-cloud color-blue";

    public string Description => "My Custom migration: NestedContent, Grid and UmbracoForms.FormPicker";

    public int Order => 10;
    
    public MigrationOptions Options => new MigrationOptions
    {
        Group = "Convert",
        Source = "uSync/v9",
        Target = $"{uSyncMigrations.MigrationFolder}/{DateTime.Now:yyyyMMdd_HHmmss}",
        Handlers = _migrationHandlers.SelectGroup(8, string.Empty),
        SourceVersion = 8,
        PreferredMigrators = new Dictionary<string, string>
        {
            { "Umbraco.NestedContent", "NestedToBlockListMigrator" },
            {  "Umbraco.Grid", "GridToBlockGridMigrator" },
            {  "UmbracoForms.FormPicker", "MyUmbracoFormsMigrator" },
        }
    };
}
