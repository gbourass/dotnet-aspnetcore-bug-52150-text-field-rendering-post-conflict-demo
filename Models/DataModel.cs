namespace DotNetWebRenderingBug.Models;

public class DataModel {
    public string? ETag { get; set; }
    public string? Name { get; set; }
    public string? Property1 { get; set; }
    public ChildData? Child { get; set; }

    public class ChildData {
        public string? ETag { get; set; }
        public string? Name { get; set; }
        public string? Property1 { get; set; }
        public string? Property2 { get; set; }
    }

    public static readonly DataModel SampleData = new DataModel {
        Name = "MainName",
        Property1 = "MainProperty1",
        ETag = "MainETag",
        Child = new ChildData {
            Name = "ChildName",
            Property1 = "ChildProperty1",
            Property2 = "ChildProperty2",
            ETag = "ChildETag"
        }
    };

    public static readonly DataModel SampleData2 = new DataModel {
        Name = "Sample2Name",
        Property1 = "Sample2Property1",
        ETag = "Sample2ETag",
        Child = new ChildData {
            Name = "Sample2ChildName",
            Property1 = "Sample2ChildProperty1",
            Property2 = "Sample2ChildProperty2",
            ETag = "Sample2ChildETag"
        }
    };
}