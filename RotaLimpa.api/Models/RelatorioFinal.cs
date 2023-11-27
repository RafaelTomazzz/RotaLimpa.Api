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

            doc.Open();

            //Título do pdf
            Font fontTitulo = FontFactory.GetFont(BaseFont.COURIER, 20);
            Paragraph paragTitulo = new Paragraph("RELATÓRIO DO TRAJETO" + "\n \n", fontTitulo);
            paragTitulo.Alignment = Element.ALIGN_CENTER;
            
            doc.Add(paragTitulo);

            //Lista de Ocorrências

            if(listaOcorrencia != null)
            {
                Font ltOcorrencia = FontFactory.GetFont(BaseFont.COURIER, 16);
                Phrase listOcorrencia = new Phrase("Lista de Ocorrências", ltOcorrencia);
                doc.Add(listOcorrencia);

                Font fontTable = FontFactory.GetFont(BaseFont.COURIER, 12);
                PdfPTable table = new PdfPTable(3);

                Paragraph coluna1 = new Paragraph("Id", fontTable);
                coluna1.Alignment = Element.ALIGN_CENTER;
                Paragraph coluna2 = new Paragraph("Tipo de Ocorrência", fontTable);
                coluna2.Alignment = Element.ALIGN_CENTER;
                Paragraph coluna3 = new Paragraph("Momento da Ocorrêcia", fontTable);
                coluna3.Alignment = Element.ALIGN_CENTER;

                var cellId = new PdfPCell(coluna1);
                var cellTipo = new PdfPCell(coluna2);
                var cellMomento = new PdfPCell(coluna3);

                table.AddCell(cellId);
                table.AddCell(cellTipo);
                table.AddCell(cellMomento);

                foreach(Ocorrencia ocorrencia in listaOcorrencia)
                {
                    Paragraph Id = new Paragraph(ocorrencia.Id.ToString(), fontTable);
                    Id.Alignment = Element.ALIGN_CENTER;
                    var cell1 = new PdfPCell(Id);
                    table.AddCell(cell1);

                    if(ocorrencia.TipoOcorrencia == TiposOcorrencia.Colisão)
                    {
                        Paragraph tipo = new Paragraph("Colisão", fontTable);
                        tipo.Alignment = Element.ALIGN_CENTER;
                        var cell2 = new PdfPCell(tipo);
                        table.AddCell(cell2);
                    }
                    else if (ocorrencia.TipoOcorrencia == TiposOcorrencia.Feita)
                    {
                        Paragraph tipo = new Paragraph("Feita", fontTable);
                        tipo.Alignment = Element.ALIGN_CENTER;
                        var cell2 = new PdfPCell(tipo);
                        table.AddCell(cell2);
                    }
                    else if (ocorrencia.TipoOcorrencia == TiposOcorrencia.ArvoreCaida)
                    {
                        Paragraph tipo = new Paragraph("Árvore Caída", fontTable);
                        tipo.Alignment = Element.ALIGN_CENTER;
                        var cell2 = new PdfPCell(tipo);
                        table.AddCell(cell2);
                    }
                    else if (ocorrencia.TipoOcorrencia == TiposOcorrencia.SemSaida)
                    {
                        Paragraph tipo = new Paragraph("Sem Saída", fontTable);
                        tipo.Alignment = Element.ALIGN_CENTER;
                        var cell2 = new PdfPCell(tipo);
                        table.AddCell(cell2);
                    }

                    Paragraph momento = new Paragraph(ocorrencia.MtOcorrencia.ToString(), fontTable);
                    momento.Alignment = Element.ALIGN_CENTER;
                    var cell3 = new PdfPCell(momento);
                    table.AddCell(cell3);

                    doc.Add(table);

                }
            }

            
            
            
            doc.Close();
        }
    }
}
