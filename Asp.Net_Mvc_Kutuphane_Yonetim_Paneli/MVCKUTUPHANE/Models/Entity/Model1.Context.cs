﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCKUTUPHANE.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBKUTUPHANEEntities : DbContext
    {
        public DBKUTUPHANEEntities()
            : base("name=DBKUTUPHANEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBL_UYE> TBL_UYE { get; set; }
        public virtual DbSet<TBL_YAZAR> TBL_YAZAR { get; set; }
        public virtual DbSet<TBLCEZA> TBLCEZA { get; set; }
        public virtual DbSet<TBLHAREKET> TBLHAREKET { get; set; }
        public virtual DbSet<TBLKASA> TBLKASA { get; set; }
        public virtual DbSet<TBLKATEGORI> TBLKATEGORI { get; set; }
        public virtual DbSet<TBLKITAP> TBLKITAP { get; set; }
        public virtual DbSet<TBLPERSONEL> TBLPERSONEL { get; set; }
        public virtual DbSet<tbl_aciklama> tbl_aciklama { get; set; }
        public virtual DbSet<tbl_iletisim> tbl_iletisim { get; set; }
        public virtual DbSet<TBL_MESAJLAR> TBL_MESAJLAR { get; set; }
        public virtual DbSet<tbl_duyurular> tbl_duyurular { get; set; }
        public virtual DbSet<tbl_admin> tbl_admin { get; set; }
    
        public virtual ObjectResult<string> enFazlaKitap()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("enFazlaKitap");
        }
    
        public virtual ObjectResult<enbasariliPersonel_Result> enbasariliPersonel()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<enbasariliPersonel_Result>("enbasariliPersonel");
        }
    
        public virtual ObjectResult<basariliPersonel_Result> basariliPersonel()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<basariliPersonel_Result>("basariliPersonel");
        }
    
        public virtual ObjectResult<string> enbasariliPersonelTWO()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("enbasariliPersonelTWO");
        }
    
        public virtual ObjectResult<string> enAktifUye()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("enAktifUye");
        }
    
        public virtual ObjectResult<string> okunanKitap()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("okunanKitap");
        }
    }
}
