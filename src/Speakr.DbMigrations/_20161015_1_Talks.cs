using FluentMigrator;

namespace Speakr.DbMigrations
{
    [Migration(1)]
    public class _20161015_1_Talks : Migration
    {
        public override void Up()
        {
            Create.Table("Talks")
                .WithColumn("TalkID").AsInt64().PrimaryKey().Identity()
                .WithColumn("TalkEasyAccessKey").AsString(32).NotNullable()
                .WithColumn("TalkName").AsString()
                .WithColumn("Topic").AsString()
                .WithColumn("Description").AsString()
                .WithColumn("SpeakerName").AsString()
                .WithColumn("TalkCreationTime").AsDateTime().NotNullable()
                .WithColumn("TalkStartTime").AsDateTime().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("Talks");
        }
    }
}
