namespace ModelDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ggg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RefuseMedicineDetails", "RefuseId", "dbo.RefuseMedicines");
            DropIndex("dbo.RefuseMedicineDetails", new[] { "RefuseId" });
            CreateTable(
                "dbo.Subscribers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNo = c.String(),
                        InsurNo = c.String(),
                        InsurName = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                        Server = c.String(),
                        ClientId = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        StopCard = c.DateTime(),
                        IsStoped = c.Boolean(),
                        Notes = c.String(),
                        localityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            AddColumn("dbo.Approves", "InsurId", c => c.Int(nullable: false));
            AddColumn("dbo.ApproveMedicines", "InsurId", c => c.Int(nullable: false));
            AddColumn("dbo.ChronicsBooks", "SubscriberId", c => c.Int(nullable: false));
            AddColumn("dbo.Reclaims", "SubscriberId", c => c.Int(nullable: false));
            CreateIndex("dbo.Approves", "InsurId");
            CreateIndex("dbo.ApproveMedicines", "InsurId");
            CreateIndex("dbo.ChronicsBooks", "SubscriberId");
            CreateIndex("dbo.Reclaims", "SubscriberId");
            AddForeignKey("dbo.Approves", "InsurId", "dbo.Subscribers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApproveMedicines", "InsurId", "dbo.Subscribers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ChronicsBooks", "SubscriberId", "dbo.Subscribers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reclaims", "SubscriberId", "dbo.Subscribers", "Id", cascadeDelete: true);
            DropColumn("dbo.Users", "LocalityId");
            DropColumn("dbo.ApproveMedicines", "PhoneNo");
            DropColumn("dbo.ApproveMedicines", "InsurNo");
            DropColumn("dbo.ApproveMedicines", "InsurName");
            DropColumn("dbo.ApproveMedicines", "Gender");
            DropColumn("dbo.ApproveMedicines", "Address");
            DropColumn("dbo.ApproveMedicines", "Server");
            DropColumn("dbo.ApproveMedicines", "ClientId");
            DropColumn("dbo.ApproveMedicines", "BirthDate");
            DropColumn("dbo.ApproveMedicines", "Notes");
            DropColumn("dbo.ChronicsBooks", "PhoneNo");
            DropColumn("dbo.ChronicsBooks", "InsurNo");
            DropColumn("dbo.ChronicsBooks", "InsurName");
            DropColumn("dbo.ChronicsBooks", "Gender");
            DropColumn("dbo.ChronicsBooks", "Address");
            DropColumn("dbo.ChronicsBooks", "Server");
            DropColumn("dbo.ChronicsBooks", "ClientId");
            DropColumn("dbo.ChronicsBooks", "BirthDate");
            DropColumn("dbo.Reclaims", "PhoneNo");
            DropColumn("dbo.Reclaims", "InsurNo");
            DropColumn("dbo.Reclaims", "InsurName");
            DropColumn("dbo.Reclaims", "Gender");
            DropColumn("dbo.Reclaims", "Address");
            DropColumn("dbo.Reclaims", "Server");
            DropColumn("dbo.Reclaims", "ClientId");
            DropColumn("dbo.Reclaims", "BirthDate");
            DropTable("dbo.RefuseMedicineDetails");
            DropTable("dbo.RefuseMedicines");
            DropTable("dbo.StopSubsribers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StopSubsribers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StopDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        InsurNo = c.String(),
                        IsStoped = c.Boolean(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RefuseMedicines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReqCenterId = c.Int(nullable: false),
                        ExcCenterId = c.Int(nullable: false),
                        RefuseDate = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                        PhoneNo = c.String(),
                        InsurNo = c.String(),
                        InsurName = c.String(),
                        Gender = c.String(),
                        Address = c.String(),
                        Server = c.String(),
                        ClientId = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RefuseMedicineDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RefuseId = c.Int(nullable: false),
                        RefuseReason = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Reclaims", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reclaims", "ClientId", c => c.String());
            AddColumn("dbo.Reclaims", "Server", c => c.String());
            AddColumn("dbo.Reclaims", "Address", c => c.String());
            AddColumn("dbo.Reclaims", "Gender", c => c.String());
            AddColumn("dbo.Reclaims", "InsurName", c => c.String());
            AddColumn("dbo.Reclaims", "InsurNo", c => c.String());
            AddColumn("dbo.Reclaims", "PhoneNo", c => c.String());
            AddColumn("dbo.ChronicsBooks", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ChronicsBooks", "ClientId", c => c.String());
            AddColumn("dbo.ChronicsBooks", "Server", c => c.String());
            AddColumn("dbo.ChronicsBooks", "Address", c => c.String());
            AddColumn("dbo.ChronicsBooks", "Gender", c => c.String());
            AddColumn("dbo.ChronicsBooks", "InsurName", c => c.String());
            AddColumn("dbo.ChronicsBooks", "InsurNo", c => c.String());
            AddColumn("dbo.ChronicsBooks", "PhoneNo", c => c.String());
            AddColumn("dbo.ApproveMedicines", "Notes", c => c.String());
            AddColumn("dbo.ApproveMedicines", "BirthDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ApproveMedicines", "ClientId", c => c.String());
            AddColumn("dbo.ApproveMedicines", "Server", c => c.String());
            AddColumn("dbo.ApproveMedicines", "Address", c => c.String());
            AddColumn("dbo.ApproveMedicines", "Gender", c => c.String());
            AddColumn("dbo.ApproveMedicines", "InsurName", c => c.String());
            AddColumn("dbo.ApproveMedicines", "InsurNo", c => c.String());
            AddColumn("dbo.ApproveMedicines", "PhoneNo", c => c.String());
            AddColumn("dbo.Users", "LocalityId", c => c.Int());
            DropForeignKey("dbo.Reclaims", "SubscriberId", "dbo.Subscribers");
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
            DropForeignKey("dbo.ChronicsBooks", "SubscriberId", "dbo.Subscribers");
            DropForeignKey("dbo.ApproveMedicines", "InsurId", "dbo.Subscribers");
            DropForeignKey("dbo.Approves", "InsurId", "dbo.Subscribers");
            DropIndex("dbo.Reclaims", new[] { "SubscriberId" });
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
            DropIndex("dbo.ChronicsBooks", new[] { "SubscriberId" });
            DropIndex("dbo.ApproveMedicines", new[] { "InsurId" });
            DropIndex("dbo.Approves", new[] { "InsurId" });
            DropColumn("dbo.Reclaims", "SubscriberId");
            DropColumn("dbo.ChronicsBooks", "SubscriberId");
            DropColumn("dbo.ApproveMedicines", "InsurId");
            DropColumn("dbo.Approves", "InsurId");
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
            DropTable("dbo.Subscribers");
            CreateIndex("dbo.RefuseMedicineDetails", "RefuseId");
            AddForeignKey("dbo.RefuseMedicineDetails", "RefuseId", "dbo.RefuseMedicines", "Id", cascadeDelete: true);
        }
    }
}
