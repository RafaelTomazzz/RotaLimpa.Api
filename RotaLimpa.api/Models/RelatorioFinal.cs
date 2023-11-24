using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace RotaLimpa.Api.Models
{
    [Table("RelatorioFinal")]
    [PrimaryKey(nameof(IdRelatorio))]
    public class RelatorioFinal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id_Relatorio")]
        [NotNull]
        public int IdRelatorio { get; set; }

        [Required]
        [ForeignKey("Id_Setor")]
        public int IdSetor { get; set; }
        public Setor? Setor { get; set; }

        [Required]
        [ForeignKey("Id_Ocorrencia")]
        public int IdOcorrencia { get; set; }
        public virtual Ocorrencia? Ocorrencia { get; set; }


        public static void CriarPDF() 
        {
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 40);
            doc.AddCreationDate();
            string caminho = @"C:\pdf\" + "relatorio.pdf";
            
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            Font fontTitulo = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 20);
            Font fontTexto = FontFactory.GetFont(BaseFont.TIMES_ROMAN, 12);

            Paragraph paragTitulo = new Paragraph("Rel�torio + Id", fontTitulo);
            paragTitulo.Alignment = Element.ALIGN_CENTER;
            
            Paragraph paragTexto = new Paragraph(
                "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna. Nunc viverra imperdiet enim.",
                fontTitulo
                );

            doc.Open();
            doc.Add(paragTitulo);
            doc.Add(paragTexto);
            doc.Close();


        }
    }
}
