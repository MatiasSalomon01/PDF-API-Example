namespace WebApi.Models;

public class ReportViewModel
{
    public string LogoUrl { get; set; } = default!;
    public string InfoIconUrl { get; set; } = default!;
    public string WarningIconUrl { get; set; } = default!;
    public string ReportDate { get; set; } = default!;
    public string RunId { get; set; } = default!;
    public string RunDate { get; set; } = default!;
    public string InstrumentSerial { get; set; } = default!;
    public string FlowCellId { get; set; } = default!;
    public string SoftwareVersion { get; set; } = default!;
    public List<QualityControlLane> QualityControlLanes { get; set; } = [];
    public List<SampleResult> DetectedSamples { get; set; } = [];
    public List<SampleResult> NotDetectedSamples { get; set; } = [];

    public static ReportViewModel Create()
    {
        return new ReportViewModel
        {
            LogoUrl = "https://placehold.co/2000x400/png",
            InfoIconUrl = "https://images.icon-icons.com/523/PNG/512/information_icon-icons.com_52388.png",
            WarningIconUrl = "https://images.icon-icons.com/1808/PNG/512/warning_115257.png",
            ReportDate = "2020-05-08 03:14",
            RunId = "200565_A00834",
            RunDate = "2020-05-08",
            InstrumentSerial = "A00834",
            FlowCellId = "HGH52DSGY",
            SoftwareVersion = "1.0.0",
            QualityControlLanes =
            [
                new QualityControlLane { Name = "Lane 1", Status = "✓ PASS", StatusColor = "var(--color-green-medium)",
                    IndexSets =
                    [
                        new QualityControlIndexSet { Name = "└ Index Set A", Status = "✓ PASS", StatusColor = "var(--color-green-medium)" },
                        new QualityControlIndexSet { Name = "└ Index Set B", Status = "✓ PASS", StatusColor = "var(--color-green-medium)" },
                        new QualityControlIndexSet { Name = "└ Index Set C", Status = "✓ PASS", StatusColor = "var(--color-green-medium)" },
                        new QualityControlIndexSet { Name = "└ Index Set D", Status = "✓ PASS", StatusColor = "var(--color-green-medium)" }
                    ]
                },
                new QualityControlLane { Name = "Lane 2", Status = "✓ PASS", StatusColor = "var(--color-green-medium)",
                    IndexSets =
                    [
                        new QualityControlIndexSet { Name = "└ Index Set A", Status = "✓ PASS", StatusColor = "var(--color-green-medium)" },
                        new QualityControlIndexSet { Name = "└ Index Set B", Status = "✓ PASS", StatusColor = "var(--color-green-medium)" },
                        new QualityControlIndexSet { Name = "└ Index Set C", Status = "✓ PASS", StatusColor = "var(--color-green-medium)" },
                        new QualityControlIndexSet { Name = "└ Index Set D", Status = "✓ PASS", StatusColor = "var(--color-green-medium)" }
                    ]
                },
                new QualityControlLane { Name = "Lane 3", Status = "✓ PASS", StatusColor = "var(--color-green-medium)",
                    IndexSets =
                    [
                        new QualityControlIndexSet { Name = "└ Index Set A", Status = "✓ PASS", StatusColor = "var(--color-green-medium)" },
                        new QualityControlIndexSet { Name = "└ Index Set B", Status = "✓ PASS", StatusColor = "var(--color-green-medium)" },
                        new QualityControlIndexSet { Name = "└ Index Set C", Status = "✓ PASS", StatusColor = "var(--color-green-medium)" },
                        new QualityControlIndexSet { Name = "└ Index Set D", Status = "✓ PASS", StatusColor = "var(--color-green-medium)" }
                    ]
                },
                new QualityControlLane { Name = "Lane 4", Status = "✓ PASS", StatusColor = "var(--color-green-medium)",
                    IndexSets =
                    [
                        new QualityControlIndexSet { Name = "└ Index Set A", Status = "✓ PASS", StatusColor = "var(--color-green-medium)" },
                        new QualityControlIndexSet { Name = "└ Index Set B", Status = "✓ PASS", StatusColor = "var(--color-green-medium)" },
                        new QualityControlIndexSet { Name = "└ Index Set C", Status = "✓ PASS", StatusColor = "var(--color-green-medium)" },
                        new QualityControlIndexSet { Name = "└ Index Set D", Status = "✓ PASS", StatusColor = "var(--color-green-medium)" }
                    ]
                }
            ],
            DetectedSamples =
            [
                new SampleResult { SampleId = "432543565", InternalControl = "N/A", Result = "SARS-CoV-2 Detected", ResultColor = "var(--color-red-medium)", ConsensusSequence = "Available", LaneIndexSet = "Lane 1 / Index Set A" },
                new SampleResult { SampleId = "948390234", InternalControl = "Pass", Result = "SARS-CoV-2 Detected", ResultColor = "var(--color-red-medium)", ConsensusSequence = "Not Available", LaneIndexSet = "Lane 2 / Index Set D" },
                new SampleResult { SampleId = "123924043", InternalControl = "Pass", Result = "SARS-CoV-2 Detected", ResultColor = "var(--color-red-medium)", ConsensusSequence = "Available", LaneIndexSet = "Lane 3 / Index Set B" }
            ],
            NotDetectedSamples = [.. Enumerable.Range(1, 10).Select(i => new SampleResult
            {
                SampleId = $"SND_{i.ToString("D7")}",
                InternalControl = "Pass",
                Result = "SARS-CoV-2 Not Detected",
                ConsensusSequence = "Not Available",
                LaneIndexSet = $"Lane {i % 4 + 1} / Index Set {((char)('A' + i % 4)).ToString()}"
            })]
        };
    }
}

public class QualityControlLane
{
    public string Name { get; set; } = default!;
    public string Status { get; set; } = default!;
    public string StatusColor { get; set; } = default!;
    public List<QualityControlIndexSet> IndexSets { get; set; } = [];
}

public class QualityControlIndexSet
{
    public string Name { get; set; } = default!;
    public string Status { get; set; } = default!;
    public string StatusColor { get; set; } = default!;
}

public class SampleResult
{
    public string SampleId { get; set; } = default!;
    public string InternalControl { get; set; } = default!;
    public string Result { get; set; } = default!;
    public string ResultColor { get; set; } = default!;
    public string ConsensusSequence { get; set; } = default!;
    public string LaneIndexSet { get; set; } = default!;
}
