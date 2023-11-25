using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using RotaLimpa.Api.Services;
using RotaLimpa.Api.Models.Enum;


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
            

            //Lista de Ocorrências
            PdfPTable table = new PdfPTable(3);

            Paragraph coluna1 = new Paragraph("Id");
            Paragraph coluna2 = new Paragraph("Tipo de Ocorrência");
            Paragraph coluna3 = new Paragraph("Momento da Ocorrêcia");

            var cellId = new PdfPCell();
            var cellTipo = new PdfPCell();
            var cellMomento = new PdfPCell();

            table.AddCell(cellId);
            table.AddCell(cellTipo);
            table.AddCell(cellMomento);

            foreach(Ocorrencia ocorrencia in listaOcorrencia)
            {
                Phrase Id = new Phrase(ocorrencia.Id.ToString());
                var cell1 = new PdfPCell(Id);
                table.AddCell(cell1);

                if(ocorrencia.TipoOcorrencia == TiposOcorrencia.Colisão)
                {
                    Phrase tipo = new Phrase("Colisão");
                    var cell2 = new PdfPCell(tipo);
                    table.AddCell(cell2);
                }
                else if (ocorrencia.TipoOcorrencia == TiposOcorrencia.Feita)
                {
                    Phrase tipo = new Phrase("Feita");
                    var cell2 = new PdfPCell(tipo);
                    table.AddCell(cell2);
                }
                else if (ocorrencia.TipoOcorrencia == TiposOcorrencia.ArvoreCaida)
                {
                    Phrase tipo = new Phrase("Árvore Caída");
                    var cell2 = new PdfPCell(tipo);
                    table.AddCell(cell2);
                }
                else if (ocorrencia.TipoOcorrencia == TiposOcorrencia.SemSaida)
                {
                    Phrase tipo = new Phrase("Sem Saída");
                    var cell2 = new PdfPCell(tipo);
                    table.AddCell(cell2);
                }

                Phrase momento = new Phrase(ocorrencia.MtOcorrencia.ToString());
                var cell3 = new PdfPCell(momento);
                table.AddCell(cell3);

            }

            doc.Open();
            doc.Add(paragTitulo);
            doc.Add(paragTexto);
            doc.Close();
        }
    }
}
