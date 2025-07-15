using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace WebApi;

public class QuestPDFDocument(byte[] logo, byte[] infoIcon, byte[] warningIcon) : IDocument
{
    public byte[] Logo { get; set; } = logo;
    public byte[] InfoIcon { get; set; } = infoIcon;
    public byte[] WarningIcon { get; set; } = warningIcon;

    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Margin(30);

            page.Header().Element(BuildHeader);

            page.Content().Element(BuildContent);

            page.Footer().Element(BuildFooter);
        });
    }

    private void BuildHeader(IContainer container)
    {
        container.Height(30).Row(x =>
         {
             x.RelativeItem().Image(Logo).FitArea();
             x.RelativeItem(2).AlignRight().Text(x =>
             {
                 x.Span("Report date ").FontSize(8);
                 x.Span(Placeholders.ShortDate()).Bold().FontSize(8);
             });
         });
    }

    private void BuildContent(IContainer container)
    {
        container.PaddingTop(20).Column(x =>
        {
            x.Item().Container().Height(30).Border(1).BorderColor(Colors.Red.Medium).AlignMiddle()
                .PaddingHorizontal(12)
                .Row(x =>
                {
                    x.ConstantItem(10).Image(WarningIcon).FitArea();
                    x.RelativeItem().PaddingLeft(10).Text("For use under an Emergency Use Authorization (EUA) Only").FontColor(Colors.Red.Medium).ExtraBold().FontSize(8);
                });

            x.Spacing(15);

            x.Item().Row(x =>
            {
                x.RelativeItem().Column(x =>
                {
                    x.Item().Text("Run Information").Bold();
                    x.Spacing(10);
                    x.Item().Container().Background(Colors.Grey.Lighten4).Padding(8).AlignMiddle().Table(x =>
                    {
                        x.ColumnsDefinition(x =>
                        {
                            x.RelativeColumn();
                            x.RelativeColumn();
                        });

                        x.Cell().PaddingVertical(1).Text("Run ID:").FontSize(7.5f).FontColor(Colors.Grey.Medium);
                        x.Cell().PaddingVertical(1).Text("123123_A00234").FontSize(7.5f).SemiBold();
                        x.Cell().PaddingVertical(1).Text("Run Date:").FontSize(7.5f).FontColor(Colors.Grey.Medium);
                        x.Cell().PaddingVertical(1).Text("2025-05-23").FontSize(7.5f).SemiBold();
                        x.Cell().PaddingVertical(1).Text("Instrument serial:").FontSize(7.5f).FontColor(Colors.Grey.Medium);
                        x.Cell().PaddingVertical(1).Text("A00234").FontSize(7.5f).SemiBold();
                        x.Cell().PaddingVertical(1).Text("Flow Cell ID:").FontSize(7.5f).FontColor(Colors.Grey.Medium);
                        x.Cell().PaddingVertical(1).Text("ASD786123").FontSize(7.5f).SemiBold();
                        x.Cell().PaddingVertical(1).Text("Software Version:").FontSize(7.5f).FontColor(Colors.Grey.Medium);
                        x.Cell().PaddingVertical(1).Text("1.0").FontSize(7.5f).SemiBold();
                    });
                });

                x.Spacing(5);

                x.RelativeItem(2.8f).Column(x =>
                {
                    x.Item().Text("Quality Control").Bold();
                    x.Spacing(10);
                    x.Item().Container().Background(Colors.Grey.Lighten4).Padding(8).AlignCenter().Table(x =>
                    {
                        x.ColumnsDefinition(x =>
                        {
                            x.RelativeColumn();
                            x.RelativeColumn();
                            x.RelativeColumn();
                            x.RelativeColumn();
                        });

                        x.Cell().Table(x =>
                        {
                            x.ColumnsDefinition(x =>
                            {
                                x.RelativeColumn();
                                x.RelativeColumn();
                            });

                            x.Cell().PaddingVertical(1).Text("Lane 1").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                            x.Cell().PaddingVertical(1).Text("└ Index Set A").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                            x.Cell().PaddingVertical(1).Text("└ Index Set B").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                            x.Cell().PaddingVertical(1).Text("└ Index Set C").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                            x.Cell().PaddingVertical(1).Text("└ Index Set D").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                        });

                        x.Cell().Table(x =>
                        {
                            x.ColumnsDefinition(x =>
                            {
                                x.RelativeColumn();
                                x.RelativeColumn();
                            });

                            x.Cell().PaddingVertical(1).Text("Lane 1").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                            x.Cell().PaddingVertical(1).Text("└ Index Set A").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                            x.Cell().PaddingVertical(1).Text("└ Index Set B").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                            x.Cell().PaddingVertical(1).Text("└ Index Set C").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                            x.Cell().PaddingVertical(1).Text("└ Index Set D").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                        });
                        x.Cell().Table(x =>
                        {
                            x.ColumnsDefinition(x =>
                            {
                                x.RelativeColumn();
                                x.RelativeColumn();
                            });

                            x.Cell().PaddingVertical(1).Text("Lane 1").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                            x.Cell().PaddingVertical(1).Text("└ Index Set A").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                            x.Cell().PaddingVertical(1).Text("└ Index Set B").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                            x.Cell().PaddingVertical(1).Text("└ Index Set C").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                            x.Cell().PaddingVertical(1).Text("└ Index Set D").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                        });
                        x.Cell().Table(x =>
                        {
                            x.ColumnsDefinition(x =>
                            {
                                x.RelativeColumn();
                                x.RelativeColumn();
                            });

                            x.Cell().PaddingVertical(1).Text("Lane 1").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                            x.Cell().PaddingVertical(1).Text("└ Index Set A").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                            x.Cell().PaddingVertical(1).Text("└ Index Set B").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                            x.Cell().PaddingVertical(1).Text("└ Index Set C").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                            x.Cell().PaddingVertical(1).Text("└ Index Set D").FontColor(Colors.Grey.Medium).FontSize(7.5f);
                            x.Cell().PaddingVertical(1).Text("✓ PASS").FontColor(Colors.Green.Medium).FontSize(6.5f).ExtraBold();

                        });
                    });
                });
            });

            x.Spacing(15);

            x.Item().Text("Invalid Results (0)").Bold();
            x.Spacing(10);
            x.Item().Container().Height(30).Background(Colors.Grey.Lighten4).AlignMiddle()
               .PaddingHorizontal(12)
               .Row(x =>
               {
                   x.ConstantItem(10).Image(InfoIcon).FitArea();
                   x.RelativeItem().PaddingLeft(10).Text("None").ExtraBold().FontSize(8);
               });

            x.Item().Text("SARS-CoV-2 Detected (3)").Bold();
            x.Item().Table(x =>
            {
                x.ColumnsDefinition(x =>
                {
                    x.RelativeColumn();
                    x.RelativeColumn();
                    x.RelativeColumn();
                    x.RelativeColumn();
                    x.RelativeColumn();
                });

                x.Header(x =>
                {
                    x.Cell().Text("Sample ID").FontSize(7.5f).FontColor(Colors.Grey.Medium);
                    x.Cell().Text("Intern Control").FontSize(7.5f).FontColor(Colors.Grey.Medium);
                    x.Cell().Text("Result").FontSize(7.5f).FontColor(Colors.Grey.Medium);
                    x.Cell().Text("Consensus Sequence").FontSize(7.5f).FontColor(Colors.Grey.Medium);
                    x.Cell().Text("Lane / Index Set").FontSize(7.5f).FontColor(Colors.Grey.Medium);

                    x.Cell().PaddingVertical(2).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);
                    x.Cell().PaddingVertical(2).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);
                    x.Cell().PaddingVertical(2).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);
                    x.Cell().PaddingVertical(2).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);
                    x.Cell().PaddingVertical(2).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);
                });

                x.Cell().Text("34534532").FontSize(8);
                x.Cell().Text("N/A").FontSize(8);
                x.Cell().Text("SARS-CoV-2 Detected").FontSize(8).FontColor(Colors.Red.Medium).Bold();
                x.Cell().Text("Available").FontSize(8);
                x.Cell().Text("Lane 1 / Index Set A").FontSize(8);

                x.Cell().PaddingVertical(4).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);
                x.Cell().PaddingVertical(4).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);
                x.Cell().PaddingVertical(4).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);
                x.Cell().PaddingVertical(4).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);
                x.Cell().PaddingVertical(4).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);


                x.Cell().Text("3453415").FontSize(8);
                x.Cell().Text("Pass").FontSize(8);
                x.Cell().Text("SARS-CoV-2 Detected").FontSize(8).FontColor(Colors.Red.Medium).Bold().FontSize(8);
                x.Cell().Text("Not Available").FontSize(8);
                x.Cell().Text("Lane 2 / Index Set D").FontSize(8);

                x.Cell().PaddingVertical(4).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);
                x.Cell().PaddingVertical(4).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);
                x.Cell().PaddingVertical(4).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);
                x.Cell().PaddingVertical(4).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);
                x.Cell().PaddingVertical(4).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);


                x.Cell().Text("12343534").FontSize(8);
                x.Cell().Text("Pass").FontSize(8);
                x.Cell().Text("SARS-CoV-2 Detected").FontSize(8).FontColor(Colors.Red.Medium).Bold().FontSize(8);
                x.Cell().Text("Available").FontSize(8);
                x.Cell().Text("Lane 3 / Index Set B").FontSize(8);

                x.Cell().PaddingVertical(4).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);
                x.Cell().PaddingVertical(4).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);
                x.Cell().PaddingVertical(4).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);
                x.Cell().PaddingVertical(4).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);
                x.Cell().PaddingVertical(4).LineHorizontal(1).LineColor(Colors.Grey.Lighten3);

            });

            x.Spacing(15);

            x.Item().Text("SARS-CoV-2 Not Detected (1501)").Bold();
            x.Item().Table(x =>
            {
                x.ColumnsDefinition(x =>
                {
                    x.RelativeColumn();
                    x.RelativeColumn();
                    x.RelativeColumn(1.5f);
                    x.RelativeColumn();
                    x.RelativeColumn();
                });

                x.Header(x =>
                {
                    x.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Container().PaddingVertical(2).Text("Sample ID").FontSize(7.5f).FontColor(Colors.Grey.Medium);
                    x.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Container().PaddingVertical(2).Text("Intern Control").FontSize(7.5f).FontColor(Colors.Grey.Medium);
                    x.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Container().PaddingVertical(2).Text("Result").FontSize(7.5f).FontColor(Colors.Grey.Medium);
                    x.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Container().PaddingVertical(2).Text("Consensus Sequence").FontSize(7.5f).FontColor(Colors.Grey.Medium);
                    x.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Container().PaddingVertical(2).Text("Lane / Index Set").FontSize(7.5f).FontColor(Colors.Grey.Medium);
                });

                for (int i = 0; i < 500; i++)
                {
                    x.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).AlignMiddle().Container().PaddingVertical(4).Text("34534532").FontSize(8);
                    x.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).AlignMiddle().Container().PaddingVertical(4).Text("N/A").FontSize(8);
                    x.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).AlignMiddle().Container().PaddingVertical(4).Text("SARS-CoV-2 Not Detected").FontSize(8).Bold();
                    x.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).AlignMiddle().Container().PaddingVertical(4).Text("Available").FontSize(8);
                    x.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).AlignMiddle().Container().PaddingVertical(4).Text("Lane 1 / Index Set A").FontSize(8);
                }
            });
        });
    }

    private static void BuildFooter(IContainer container)
    {
        container.Height(30).AlignRight().AlignBottom().Container()
            .Background(Colors.Grey.Lighten4).AlignMiddle().PaddingVertical(5).PaddingHorizontal(10)
            .Text(x =>
            {
                x.DefaultTextStyle(x => x.ExtraBold().FontSize(7));
                x.AlignCenter();
                x.CurrentPageNumber();
                x.Span(" of ");
                x.TotalPages();
            });
    }
}
