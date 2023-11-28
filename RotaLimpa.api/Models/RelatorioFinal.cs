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
using RotaLimpa.Api.Data;


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

        

        public async void CriarPDF(RelatorioFinal relatorioFinal, Trajeto trajeto, Setor setor, IEnumerable<Ocorrencia> listaOcorrencia, Motorista motorista, IEnumerable<CEP> listaCEP) 
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

            Font fontTitulo = FontFactory.GetFont(BaseFont.COURIER, 20, Font.BOLD);
            Font fontSubtitulo = FontFactory.GetFont(BaseFont.COURIER, 16, Font.BOLD);
            Font fontText = FontFactory.GetFont(BaseFont.COURIER, 12);
            Paragraph paragTitulo = new Paragraph("RELATÓRIO DO TRAJETO" + "\n \n", fontTitulo);
            paragTitulo.Alignment = Element.ALIGN_CENTER;
            
            doc.Add(paragTitulo);

            //informaçoes do trajeto

            Paragraph tituloTrajeto = new Paragraph("   Informações do Trajeto \n \n", fontSubtitulo);
            doc.Add(tituloTrajeto);

            Phrase idTrajeto = new Phrase("Identidicação do Trajeto: " + trajeto.Id.ToString() + "\n", fontText);
            Phrase miTrajeto = new Phrase("Momento Inicial: " + trajeto.MiTrajeto + "\n", fontText);
            Phrase mfTrajeto = new Phrase("Momento Final: " + trajeto.MfTrajeto + "\n \n", fontText);

            Paragraph infoTrajeto = new Paragraph();
            infoTrajeto.Add(idTrajeto);
            infoTrajeto.Add(miTrajeto);
            infoTrajeto.Add(mfTrajeto);
            
            doc.Add(infoTrajeto);

            //informações do motorista

            Paragraph tituloMotorista = new Paragraph("   Informações do Motorista \n \n", fontSubtitulo);
            doc.Add(tituloMotorista);

            Phrase idMotorista = new Phrase("Identificação do Motorista: " + motorista.Id.ToString() + "\n", fontText);
            Phrase nomeMotorista = new Phrase("Nome do Motorista: " + motorista.PNome + " " + motorista.SNome + "\n", fontText);
            Phrase cpfMotorista = new Phrase("CPF do Motorista: " + motorista.Cpf + "\n", fontText);
            Phrase rgMotorista = new Phrase("RG do Motorista: " + motorista.Rg + "\n" + "\n", fontText);

            Paragraph infoMotorista = new Paragraph();
            infoMotorista.Add(idMotorista);
            infoMotorista.Add(nomeMotorista);
            infoMotorista.Add(cpfMotorista);
            infoMotorista.Add(rgMotorista);

            doc.Add(infoMotorista);

            //informaçôes do setor

            Paragraph tituloSetor = new Paragraph("   Informações do Setor \n \n", fontSubtitulo);
            doc.Add(tituloSetor);

            Phrase tipoSetor = new Phrase("", fontText);
            Phrase idSetor = new Phrase("Identificação do Setor: " + setor.Id + "\n", fontText);
            if(setor.TipoServico == TiposServico.ColeraLixo)
            {
                var tipo = "Tipo de Setor: Coleta de Lixo \n \n";
                tipoSetor.Add(tipo);
            }
            else if (setor.TipoServico == TiposServico.ColetaMato)
            {
                var tipo = "Tipo de Setor: Coleta de Mato \n \n";
                tipoSetor.Add(tipo);
            }
            else if (setor.TipoServico == TiposServico.ColetaVarricao)
            {
                var tipo = "Tipo de Setor: Varrição \n \n";
                tipoSetor.Add(tipo);
            }
            Paragraph infoSetor= new Paragraph();
            infoSetor.Add(idSetor);
            infoSetor.Add(tipoSetor);

            doc.Add(infoSetor);

            //informações do veiculo


            //Lista de Ocorrências

            if(listaOcorrencia != null)
            {
                Phrase listOcorrencia = new Phrase("   Lista de Ocorrências", fontSubtitulo);
                doc.Add(listOcorrencia);

                Font fontTable = FontFactory.GetFont(BaseFont.COURIER, 12);
                PdfPTable table = new PdfPTable(4);

                Paragraph coluna1 = new Paragraph("Id", fontTable);
                coluna1.Alignment = Element.ALIGN_CENTER;
                Paragraph coluna2 = new Paragraph("Tipo de Ocorrência", fontTable);
                coluna2.Alignment = Element.ALIGN_CENTER;
                Paragraph coluna3 = new Paragraph("Local da Ocorrência", fontTable);
                coluna3.Alignment = Element.ALIGN_CENTER;
                Paragraph coluna4 = new Paragraph("Momento da Ocorrêcia", fontTable);
                coluna3.Alignment = Element.ALIGN_CENTER;

                var cellId = new PdfPCell(coluna1);
                var cellTipo = new PdfPCell(coluna2);
                var cellLocal = new PdfPCell(coluna3);
                var cellMomento = new PdfPCell(coluna4);

                table.AddCell(cellId);
                table.AddCell(cellTipo);
                table.AddCell(cellLocal);
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

                    IEnumerable<CEP> cep = listaCEP.Where(c => c.Id == ocorrencia.IdCep);
                    var endereco = "";
                    foreach(CEP objcep in cep)
                    {
                        endereco = objcep.Endereco;
                    }
                    Paragraph local = new Paragraph(endereco, fontText);
                    local.Alignment = Element.ALIGN_CENTER;
                    var cell3 = new PdfPCell(local);
                    table.AddCell(cell3);

                    Paragraph momento = new Paragraph(ocorrencia.MtOcorrencia.ToString(), fontTable);
                    momento.Alignment = Element.ALIGN_CENTER;
                    var cell4 = new PdfPCell(momento);
                    table.AddCell(cell4);
                }
                
                doc.Add(table);
            }
            
            doc.Close();
        }
    }
}
