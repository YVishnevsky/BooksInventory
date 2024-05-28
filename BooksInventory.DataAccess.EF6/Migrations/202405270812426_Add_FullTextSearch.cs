namespace BooksInventory.DataAccess.EF6.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Add_FullTextSearch : DbMigration
    {
        public override void Up()
        {
            Sql("""
                CREATE FULLTEXT CATALOG [FT_Books] WITH ACCENT_SENSITIVITY = OFF
                CREATE FULLTEXT INDEX ON [dbo].[Books] KEY INDEX [PK_dbo.Books] ON ([FT_Books]) WITH (CHANGE_TRACKING AUTO)
                ALTER FULLTEXT INDEX ON [dbo].[Books] ADD ([Author])
                ALTER FULLTEXT INDEX ON [dbo].[Books] ADD ([ISBN])
                ALTER FULLTEXT INDEX ON [dbo].[Books] ADD ([Title])
                ALTER FULLTEXT INDEX ON [dbo].[Books] ENABLE
                """, true);
        }

        public override void Down()
        {
            Sql("""
                DROP FULLTEXT INDEX ON [dbo].[Books]
                DROP FULLTEXT CATALOG [FT_Books]
                """, true);
        }
    }
}
