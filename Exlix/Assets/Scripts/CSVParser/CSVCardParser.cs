using System.IO;
using System.Text;

public class CSVCardParser : CSVParser<CardDataTemplate> {
    public CSVCardParser(string path) : base(path) {}

    public override void ReadData() {
        foreach(var line in File.ReadAllLines(Path, Encoding.GetEncoding(65001))){
            var parts = line.Split(',');
            if(parts[0].ToString() == "카드번호") {
                continue;
            }

            DataList.Add(new CardDataTemplate (
                uint.Parse(parts[0].ToString()),
                parts[1].ToString(),
                parts[2].ToString(),
                uint.Parse(parts[3].ToString()),
                parts[4].ToString(),
                parts[5].ToString(),
                uint.Parse(parts[6].ToString()),
                uint.Parse(parts[7].ToString()),
                uint.Parse(parts[8].ToString()),
                uint.Parse(parts[9].ToString()),
                uint.Parse(parts[10].ToString()),
                parts[11].ToString(),
                uint.Parse(parts[12].ToString()),
                parts[13].ToString(),
                parts[14].ToString(),
                parts[15].ToString()
            ));
        }        
    }
}
