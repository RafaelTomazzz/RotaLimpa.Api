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
using RotaLimpa.Api.Services;


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
        [ForeignKey("Id_Trajeto")]
        public int IdTrajeto { get; set; }
        public virtual Trajeto? Trajeto { get; set; }

        
        public async void CriarPDF(RelatorioFinal relatorioFinal, Trajeto trajeto, Setor setor, IEnumerable<Ocorrencia> listaOcorrencia) 
        {
            Document doc = new Document(PageSize.A4);
            doc.SetMargins(40, 40, 40, 40);
            doc.AddCreationDate();

            //Nome do arquivo
            string nomeArquivo = "relatorio" + relatorioFinal.IdRelatorio + ".pdf";
            string caminho = @"C:\pdf\" + nomeArquivo;
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(caminho, FileMode.Create));

            //Título do pdf
            Font fontTitulo = FontFactory.GetFont(BaseFont.COURIER, 20);
            Paragraph paragTitulo = new Paragraph("RELATÓRIO" + relatorioFinal.IdRelatorio + "\n \n", fontTitulo);
            paragTitulo.Alignment = Element.ALIGN_CENTER;            
            
            Font fontTexto = FontFactory.GetFont(BaseFont.COURIER, 12);
            Paragraph paragTexto = new Paragraph(
                "Ocorrências: " + relatorioFinal.IdTrajeto + "\n" +
                "Setor:" + relatorioFinal.IdSetor,
                fontTexto
                );    
            
            Paragraph paragTexto2 = new Paragraph(
                "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna. Nunc viverra imperdiet enim.\n",
                fontTexto
                );

            doc.Open();
            doc.Add(paragTitulo);
            doc.Add(paragTexto);
            doc.Add(paragTexto2);
            doc.Close();
        }
    }
}
