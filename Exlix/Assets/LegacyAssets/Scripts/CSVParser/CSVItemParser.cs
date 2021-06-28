using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class CSVItemParser : CSVParser<ItemDataTemplate> {
    public CSVItemParser(string path) : base(path) { }

    public override void ReadData() {
        foreach (var line in File.ReadAllLines(Path, Encoding.GetEncoding(65001)))
        {
            var parts = line.Split(',');
            if (parts[0].ToString() == "장비번호") {
                continue;
            }

            DataList.Add(new ItemDataTemplate(
                uint.Parse(parts[0].ToString()),
                parts[1].ToString(),
                parts[2].ToString(),
                parts[3].ToString(),
                uint.Parse(parts[4].ToString()),
                uint.Parse(parts[5].ToString()),
                uint.Parse(parts[6].ToString()),
                uint.Parse(parts[7].ToString()),
                parts[8].ToString()
                ));
        }
    }
}
