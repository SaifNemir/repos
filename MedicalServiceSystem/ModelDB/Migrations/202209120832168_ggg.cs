namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ggg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClmContractTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractName = c.String(),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClmDetailsDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MasterId = c.Int(nullable: false),
                        GenericId = c.Int(nullable: false),
                        TradeName = c.String(),
                        Qty = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NonConfItem = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NonConfVisit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NonConfClaims = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClmMasterDatas", t => t.MasterId, cascadeDelete: true)
                .ForeignKey("dbo.Medicines", t => t.GenericId, cascadeDelete: true)
                .Index(t => t.MasterId)
                .Index(t => t.GenericId);
            
            CreateTable(
                "dbo.ClmMasterDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CenterId = c.Int(nullable: false),
                        ContractId = c.Int(nullable: false),
                        DaignosisId = c.Int(nullable: false),
                        ImpId = c.Int(nullable: false),
                        FileNo = c.Int(nullable: false),
                        Months = c.Int(nullable: false),
                        Years = c.Int(nullable: false),
                        NoOfFile = c.Int(nullable: false),
                        VisitNo = c.String(),
                        VisitDate = c.DateTime(nullable: false),
                        InsuranceNo = c.Double(nullable: false),
                        PatName = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        CleintId = c.Int(nullable: false),
                        ReviewDocId = c.Int(),
                        ReviewDate = c.DateTime(),
                        ApproveUserId = c.Int(),
                        ApproveDate = c.DateTime(),
                        IsReviewed = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CenterInfoes", t => t.CenterId, cascadeDelete: true)
                .ForeignKey("dbo.ClmContractTypes", t => t.ContractId, cascadeDelete: true)
                .ForeignKey("dbo.Diagnosis", t => t.DaignosisId, cascadeDelete: true)
                .Index(t => t.CenterId)
                .Index(t => t.ContractId)
                .Index(t => t.DaignosisId);
            
            CreateTable(
                "dbo.ClmErrorDataEnters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceiptId = c.Int(nullable: false),
                        ErrorId = c.Int(nullable: false),
                        ErrorGroup = c.Int(nullable: false),
                        VistNo = c.Int(nullable: false),
                        EmpName = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Counts = c.Int(nullable: false),
                        Notes = c.String(),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClmErrorTypes", t => t.ErrorId, cascadeDelete: true)
                .ForeignKey("dbo.ClmReceiptClaims", t => t.ReceiptId, cascadeDelete: true)
                .Index(t => t.ReceiptId)
                .Index(t => t.ErrorId);
            
            CreateTable(
                "dbo.ClmErrorTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ErrorName = c.String(),
                        ErrorGroup = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClmReceiptClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Month = c.Int(nullable: false),
                        year = c.Int(nullable: false),
                        CenterId = c.Int(nullable: false),
                        ContactName = c.String(),
                        ContactTell = c.String(),
                        NextDate = c.DateTime(nullable: false),
                        ReceiptDate = c.DateTime(nullable: false),
                        TimeIn = c.DateTime(nullable: false),
                        TimeOut = c.DateTime(nullable: false),
                        Notes = c.String(),
                        Sorted = c.Int(nullable: false),
                        DataEntery = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CenterInfoes", t => t.CenterId, cascadeDelete: true)
                .Index(t => t.CenterId);
            
            CreateTable(
                "dbo.ClmImpFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileNo = c.Int(nullable: false),
                        CenterId = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        year = c.Int(nullable: false),
                        ImpDate = c.DateTime(nullable: false),
                        Counts = c.Int(nullable: false),
                        DrogCount = c.Int(nullable: false),
                        FilePath = c.String(),
                        Costs = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClmStatus = c.Int(nullable: false),
                        TemporaryUserId = c.Int(),
                        TemporaryDate = c.DateTime(),
                        ImportUserId = c.Int(),
                        ImportDate = c.DateTime(),
                        ReceiptUserId = c.Int(),
                        ReceiptDate = c.DateTime(),
                        EnabledUserId = c.Int(),
                        EnabledDate = c.DateTime(),
                        RequestUserId = c.Int(),
                        RequestDate = c.DateTime(),
                        AllocationUserId = c.Int(),
                        AllocationtDate = c.DateTime(),
                        ReviewUserId = c.Int(),
                        ReviewDate = c.DateTime(),
                        ApproveUserId = c.Int(),
                        ApproveDate = c.DateTime(),
                        CompleteId = c.Int(),
                        CompleteDate = c.DateTime(),
                        AllocatedDocId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CenterInfoes", t => t.CenterId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.AllocatedDocId, cascadeDelete: true)
                .Index(t => t.CenterId)
                .Index(t => t.AllocatedDocId);
            
            CreateTable(
                "dbo.ClmNonConfirmDets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MasterId = c.Int(nullable: false),
                        NonConfirmId = c.Int(nullable: false),
                        DetailsId = c.Int(),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Percent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClmMasterDatas", t => t.MasterId, cascadeDelete: true)
                .ForeignKey("dbo.ClmNonConfirmTypes", t => t.NonConfirmId, cascadeDelete: true)
                .Index(t => t.MasterId)
                .Index(t => t.NonConfirmId);
            
            CreateTable(
                "dbo.ClmNonConfirmTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ValueType = c.Int(nullable: false),
                        DicountType = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClmReceiptClaimsDets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceiptId = c.Int(nullable: false),
                        FileNo = c.Int(nullable: false),
                        FileName = c.String(),
                        CountOfOrneks = c.Int(nullable: false),
                        TotalOfClaims = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CountOfError = c.Int(nullable: false),
                        Percent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CountOfBoxFile = c.Int(nullable: false),
                        ImpId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClmReceiptClaims", t => t.ReceiptId, cascadeDelete: true)
                .Index(t => t.ReceiptId);
            
            CreateTable(
                "dbo.ClmSortedDegs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClmTempDets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MasterId = c.Int(nullable: false),
                        GenericId = c.Int(nullable: false),
                        TradeName = c.String(),
                        Qty = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClmTempMasters", t => t.MasterId, cascadeDelete: true)
                .ForeignKey("dbo.Medicines", t => t.GenericId, cascadeDelete: true)
                .Index(t => t.MasterId)
                .Index(t => t.GenericId);
            
            CreateTable(
                "dbo.ClmTempMasters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CenterId = c.Int(nullable: false),
                        ContractId = c.Int(nullable: false),
                        DaignosisId = c.Int(nullable: false),
                        ImpId = c.Int(nullable: false),
                        FileNo = c.Int(nullable: false),
                        Months = c.Int(nullable: false),
                        Years = c.Int(nullable: false),
                        NoOfFile = c.Int(nullable: false),
                        VisitNo = c.String(),
                        VisitDate = c.DateTime(nullable: false),
                        InsuranceNo = c.Double(nullable: false),
                        PatName = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        CleintId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        DateIn = c.DateTime(nullable: false),
                        UpdateUser = c.Int(),
                        UpdateDate = c.DateTime(),
                        UserDeleted = c.Int(),
                        DeleteDate = c.DateTime(),
                        Status = c.Int(nullable: false),
                        RowStatus = c.Int(nullable: false),
                        LocalityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Reclaims", "SectorName", c => c.String());
            AddColumn("dbo.Reclaims", "SectorId", c => c.Int());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClmTempDets", "GenericId", "dbo.Medicines");
            DropForeignKey("dbo.ClmTempDets", "MasterId", "dbo.ClmTempMasters");
            DropForeignKey("dbo.ClmReceiptClaimsDets", "ReceiptId", "dbo.ClmReceiptClaims");
            DropForeignKey("dbo.ClmNonConfirmDets", "NonConfirmId", "dbo.ClmNonConfirmTypes");
            DropForeignKey("dbo.ClmNonConfirmDets", "MasterId", "dbo.ClmMasterDatas");
            DropForeignKey("dbo.ClmImpFiles", "AllocatedDocId", "dbo.Users");
            DropForeignKey("dbo.ClmImpFiles", "CenterId", "dbo.CenterInfoes");
            DropForeignKey("dbo.ClmErrorDataEnters", "ReceiptId", "dbo.ClmReceiptClaims");
            DropForeignKey("dbo.ClmReceiptClaims", "CenterId", "dbo.CenterInfoes");
            DropForeignKey("dbo.ClmErrorDataEnters", "ErrorId", "dbo.ClmErrorTypes");
            DropForeignKey("dbo.ClmDetailsDatas", "GenericId", "dbo.Medicines");
            DropForeignKey("dbo.ClmDetailsDatas", "MasterId", "dbo.ClmMasterDatas");
            DropForeignKey("dbo.ClmMasterDatas", "DaignosisId", "dbo.Diagnosis");
            DropForeignKey("dbo.ClmMasterDatas", "ContractId", "dbo.ClmContractTypes");
            DropForeignKey("dbo.ClmMasterDatas", "CenterId", "dbo.CenterInfoes");
            DropIndex("dbo.ClmTempDets", new[] { "GenericId" });
            DropIndex("dbo.ClmTempDets", new[] { "MasterId" });
            DropIndex("dbo.ClmReceiptClaimsDets", new[] { "ReceiptId" });
            DropIndex("dbo.ClmNonConfirmDets", new[] { "NonConfirmId" });
            DropIndex("dbo.ClmNonConfirmDets", new[] { "MasterId" });
            DropIndex("dbo.ClmImpFiles", new[] { "AllocatedDocId" });
            DropIndex("dbo.ClmImpFiles", new[] { "CenterId" });
            DropIndex("dbo.ClmReceiptClaims", new[] { "CenterId" });
            DropIndex("dbo.ClmErrorDataEnters", new[] { "ErrorId" });
            DropIndex("dbo.ClmErrorDataEnters", new[] { "ReceiptId" });
            DropIndex("dbo.ClmMasterDatas", new[] { "DaignosisId" });
            DropIndex("dbo.ClmMasterDatas", new[] { "ContractId" });
            DropIndex("dbo.ClmMasterDatas", new[] { "CenterId" });
            DropIndex("dbo.ClmDetailsDatas", new[] { "GenericId" });
            DropIndex("dbo.ClmDetailsDatas", new[] { "MasterId" });
            DropColumn("dbo.Reclaims", "SectorId");
            DropColumn("dbo.Reclaims", "SectorName");
            DropTable("dbo.ClmTempMasters");
            DropTable("dbo.ClmTempDets");
            DropTable("dbo.ClmSortedDegs");
            DropTable("dbo.ClmReceiptClaimsDets");
            DropTable("dbo.ClmNonConfirmTypes");
            DropTable("dbo.ClmNonConfirmDets");
            DropTable("dbo.ClmImpFiles");
            DropTable("dbo.ClmReceiptClaims");
            DropTable("dbo.ClmErrorTypes");
            DropTable("dbo.ClmErrorDataEnters");
            DropTable("dbo.ClmMasterDatas");
            DropTable("dbo.ClmDetailsDatas");
            DropTable("dbo.ClmContractTypes");
        }
    }
}
