using GameFramework.DataTable;
using GameFramework;
using UnityGameFramework.Runtime;
using System.Data;
using System.IO;
using System.Text;

public class DRHero : IDataRow
{
    private int m_Id = 0;

    public int Id { get => m_Id; }
    public string name { get; private set; }
    public int attack { get; private set; }
    //ÖØÐÂ
    public  bool ParseDataRow(string dataRowString, object userData)
    {
        string[] columnStrings = dataRowString.Split('\t');
        for (int i = 0; i < columnStrings.Length; i++)
        {
            columnStrings[i] = columnStrings[i].Trim('\"');
        }

        int index = 0;
        index++;
        m_Id = int.Parse(columnStrings[index++]);
        name = (columnStrings[index++]);
        attack = int.Parse(columnStrings[index++]);
        return true;
    }

    public bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
    {
        throw new System.NotImplementedException();
        //using (MemoryStream memoryStream = new MemoryStream(dataRowBytes, startIndex, length, false))
        //{
        //    using (BinaryReader binaryReader = new BinaryReader(memoryStream, Encoding.UTF8))
        //    {
        //        m_Id = binaryReader.Read7BitEncodedInt32();
        //        name = binaryReader.ReadString();
        //        attack = binaryReader.Read7BitEncodedInt32();
        //    }
        //}

        //return true;
    }
}
