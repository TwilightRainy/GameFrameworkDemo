using GameFramework.DataTable;
using GameFramework;
using UnityGameFramework.Runtime;
using System.Data;
using System.IO;
using System.Text;

public class DRHero : DataRowBase
{
    private int m_Id = 0;

    public override int Id { get => m_Id; }
    public string name { get; private set; }
    public int attack { get; private set; }
    //ÖØÐÂ
    public override bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = dataRowString.Split('\t');
        for (int i = 0; i < columnStrings.Length; i++)
        {
            columnStrings[i] = columnStrings[i].Trim('\"');
        }

        int index = 0;
        index++;
        m_Id = int.Parse(columnStrings[index++]);
        index++;
        name = (columnStrings[index++]);
        attack = int.Parse(columnStrings[index++]);


        GeneratePropertyArray();
        return true;
    }

    public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        using (MemoryStream memoryStream = new MemoryStream(dataRowBytes, startIndex, length, false))
        {
            using (BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8))
            {
                m_Id = binaryReader.Read7BitEncodedInt32();
                name = binaryReader.ReadString();
                attack = binaryReader.Read7BitEncodedInt32();
            }
        }

        GeneratePropertyArray();
        return true;
    }

    private void GeneratePropertyArray()
    {

    }
}
