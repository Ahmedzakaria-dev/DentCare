using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Attachment
    {
        public int AttachmentId { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FilePath { get; set; }

        public string? FileType { get; set; }

        public DateTime UploadDate { get; set; } = DateTime.Now;

        // Medical Record

        public int MedicalRecordId { get; set; }

        public MedicalRecord MedicalRecord { get; set; }
    }
}
