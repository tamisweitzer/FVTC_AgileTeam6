//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BandZone.PL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblMusician
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblMusician()
        {
            this.tblMusicGenre = new HashSet<tblMusicGenre>();
        }
    
        public int MusicianId { get; set; }
        public string BandMusicianName { get; set; }
        public Nullable<int> SongId { get; set; }
        public string Phone { get; set; }
        public string ContactEmail { get; set; }
        public string Website { get; set; }
        public string ProfileImage { get; set; }
        public string LoginEmail { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblMusicGenre> tblMusicGenre { get; set; }
    }
}
