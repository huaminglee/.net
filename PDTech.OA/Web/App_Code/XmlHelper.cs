using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.Xml;
using System.Web.Configuration;
using System.Collections;
using System.IO;
using System.Xml.Serialization;

/// <summary>
/// XML配置文件帮助类
/// </summary>
public class XmlHelper
{
    public static XmlHelper Local
    {
        get
        {
            return new XmlHelper("siteConfigFileUri");
        }
    }

    string filePath = "";
    XmlHelper(string configFileUri)
    {
        filePath = HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings[configFileUri]);
    }

    /// <summary>
    /// 用数据表返回指定节点的xml文档内容
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="sXmlNode"></param>
    /// <returns></returns>
    public DataTable GetNodeList(string sXmlNode)
    {
        DataSet ds = new DataSet();
        //定义一个操作的xml文档
        XmlDocument doc = new XmlDocument();
        //载入文档
        doc.Load(filePath);
        XmlNode node = doc.SelectSingleNode("//" + sXmlNode);

        StringReader sr = new StringReader(node.OuterXml);

        ds.ReadXml(sr);
        doc = null;
        DataTable data = null;
        if (ds.Tables.Count > 0)
        {
            data = ds.Tables[0];
        }
        return data;
    }
    /// <summary>
    /// 用数据表返回指定节点的xml文档内容
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="sXmlNode"></param>
    /// <returns></returns>
    public static DataTable GetNodeList(string sPath, string sXmlNode)
    {
        DataSet ds = new DataSet();
        //定义一个操作的xml文档
        XmlDocument doc = new XmlDocument();
        //载入文档
        doc.Load(sPath);
        XmlNode node = doc.SelectSingleNode("//" + sXmlNode);

        StringReader sr = new StringReader(node.OuterXml);

        ds.ReadXml(sr);
        doc = null;
        DataTable data = null;
        if (ds.Tables.Count > 0)
        {
            data = ds.Tables[0];
        }
        return data;
    }
    /// <summary>
    /// 获取指定节点的内容
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="sXmlNode"></param>
    /// <returns></returns>
    public string GetNodeValue(string sXmlNode)
    {
        string sResult = string.Empty;
        //定义一个文档
        XmlDocument doc = new XmlDocument();
        //载入对象
        doc.Load(filePath);
        XmlNode node = doc.SelectSingleNode("//" + sXmlNode);
        if (node != null)
        {
            sResult = node.InnerText;
        }
        doc = null;
        return sResult;
    }
    /// <summary>
    /// 获取指定节点的内容
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="sXmlNode"></param>
    /// <returns></returns>
    public static string GetNodeValue(string sPath, string sXmlNode)
    {
        string sResult = string.Empty;
        //定义一个文档
        XmlDocument doc = new XmlDocument();
        //载入对象
        doc.Load(sPath);
        XmlNode node = doc.SelectSingleNode("//" + sXmlNode);
        if (node != null)
        {
            sResult = node.InnerText;
        }
        doc = null;
        return sResult;
    }
    /// <summary>
    /// 设置节点的内容
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="sXmlNode"></param>
    /// <param name="NewValue"></param>
    public void SetNodeValue(string sXmlNode, string NewValue)
    {
        //定义xml文档模型
        XmlDocument doc = new XmlDocument();

        //载入文档
        doc.Load(filePath);
        //获取指定的节点
        XmlNode node = doc.SelectSingleNode("//" + sXmlNode);
        if (node != null)
        {
            node.InnerText = NewValue;
            doc.Save(filePath);
            doc = null;
        }
    }


    /// <summary>
    /// 设置节点的内容
    /// </summary>
    /// <param name="filePath">文档名称</param>
    /// <param name="sXmlNode">节点名称</param>
    /// <param name="sNewValue">节点的值</param>
    /// <param name="AttribList">节点内的属性的Hashtable集合</param>
    public void SetNodeValue(string sXmlNode, string sNewValue, Hashtable AttribList)
    {
        //定义xml文档模型
        XmlDocument doc = new XmlDocument();

        //载入文档
        doc.Load(filePath);
        //获取指定的节点
        XmlNode node = doc.SelectSingleNode("//" + sXmlNode);
        if (node != null)
        {

            for (int i = 0; i < node.Attributes.Count; i++)
            {
                if (AttribList.Contains(node.Attributes[i].Name))
                {
                    try
                    {
                        node.Attributes[i].Value = AttribList[node.Attributes[i].Name].ToString();
                    }
                    catch { }
                }
            }

            if (sNewValue != "")
            {
                node.InnerText = sNewValue;
            }
            doc.Save(filePath);
            doc = null;
        }
    }

    /// <summary>
    /// 插入元素
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="sMainNode">父节点</param>
    /// <param name="sNewNodeName">元素的名称</param>
    /// <param name="AttribList">元素的属性集合</param>
    /// <param name="sNewNodeValue">元素的值</param>
    /// <param name="child">父节点是否是根节点</param>
    public void InsertNodt(string sMainNode, string sNewNodeName, Hashtable AttribList, string sNewNodeValue, bool child)
    {
        //定义xml文档模型
        XmlDocument doc = new XmlDocument();

        //载入文档
        doc.Load(filePath);

        //获取指定的节点
        XmlNode node;
        if (child)
        {
            node = doc.SelectSingleNode("//" + sMainNode);
        }
        else
        {
            node = doc.SelectSingleNode("Root");
        }


        if (node != null)
        {
            XmlElement element = doc.CreateElement(sNewNodeName);
            foreach (DictionaryEntry obj in AttribList)
            {
                element.SetAttribute(obj.Key.ToString(), obj.Value.ToString());
            }


            if (sNewNodeValue != "")
            {
                element.InnerText = sNewNodeValue;
            }

            node.AppendChild(element);
            doc.Save(filePath);
            doc = null;
        }
    }
    /// <summary>
    /// 删除元素
    /// </summary>
    /// <param name="filePath">路径</param>
    /// <param name="sMainNode">父节点</param>
    /// <param name="sDelNodeName">节点名称</param>
    public void DeleteNode(string sMainNode, string sDelNodeName)
    {
        //定义xml文档模型
        XmlDocument doc = new XmlDocument();

        //载入文档
        doc.Load(filePath);
        XmlNode node = doc.SelectSingleNode("//" + sMainNode);
        if (node != null)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Attributes["Name"].Value == sDelNodeName)
                {
                    node.RemoveChild(child);
                }
            }
        }
        doc.Save(filePath);
        doc = null;
    }
    /// <summary>
    /// 修改元素属性
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <param name="sMainNode">父节点</param>
    /// <param name="sUpNodeName">节点名称</param>
    /// <param name="sUpNodeValue">节点值</param>
    public void UpdateNode(string sMainNode, string sUpNodeName, string sUpNodeValue, string SoldNodeName)
    {
        //定义xml文档模型
        XmlDocument doc = new XmlDocument();

        //载入文档
        doc.Load(filePath);
        XmlNode node = doc.SelectSingleNode("//" + sMainNode);
        if (node != null)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Attributes["Name"].Value == SoldNodeName)
                {
                    child.Attributes["Name"].Value = sUpNodeName;
                    child.Attributes["Value"].Value = sUpNodeValue;
                }
            }
        }
        doc.Save(filePath);
        doc = null;
    }
    public void UpdateValueNode(string sMainNode, string sUpNodeValue, string SoldNodeValue)
    {
        //定义xml文档模型
        XmlDocument doc = new XmlDocument();

        //载入文档
        doc.Load(filePath);
        XmlNode node = doc.SelectSingleNode("//" + sMainNode);
        if (node != null)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Attributes["Value"].Value == SoldNodeValue)
                {
                    child.Attributes["Value"].Value = sUpNodeValue;
                }
            }
        }
        doc.Save(filePath);
        doc = null;
    }
    public void DeleteValue(string sMainNode, string sUpNodeValue)
    {
        //定义xml文档模型
        XmlDocument doc = new XmlDocument();

        //载入文档
        doc.Load(filePath);
        XmlNode node = doc.SelectSingleNode("//" + sMainNode);
        if (node != null)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Attributes["Value"].Value == sUpNodeValue)
                {
                    node.RemoveChild(child);
                }
            }
        }
        doc.Save(filePath);
        doc = null;
    }

    /// <summary>
    /// 修改多元素属性
    /// </summary>
    /// <param name="filePath">文件路径</param>
    /// <param name="sMainNode">父节点</param>
    /// <param name="sUpNodeName">节点名称</param>
    /// <param name="sUpNodeValue">节点值</param>
    /// <param name="SupBool">是否必填</param>
    public void UpdateAnyNode(string sMainNode, string sUpNodeName, string sUpNodeValue, string SoldNodeName, string SupBool)
    {
        //定义xml文档模型
        XmlDocument doc = new XmlDocument();

        //载入文档
        doc.Load(filePath);
        XmlNode node = doc.SelectSingleNode("//" + sMainNode);
        if (node != null)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Attributes["Name"].Value == SoldNodeName)
                {
                    child.Attributes["Name"].Value = sUpNodeName;
                    child.Attributes["Value"].Value = sUpNodeValue;
                    child.Attributes["Isfillout"].Value = SupBool;
                }
            }
        }
        doc.Save(filePath);
        doc = null;
    }
    /// <summary>
    /// 获取节点的特定属性
    /// </summary>
    /// <param name="sPath"></param>
    /// <param name="sNodeName"></param>
    /// <param name="attribute">属性值</param>
    /// <returns></returns>
    public static string GetAttribute(string sPath, string sNodeName, string attribute)
    {
        XmlDocument doc = new XmlDocument();
        Hashtable ht = new Hashtable();
        doc.Load(sPath);
        XmlNode nodes = null;
        if (doc.HasChildNodes)
        {
            nodes = doc.SelectSingleNode("//" + sNodeName);
            SeachChild(nodes, ref ht);
        }

        if (nodes != null)
        {
            return nodes.Attributes[attribute].Value.ToString();
        }

        return "";
    }
    public static void SeachChild(XmlNode nodes, ref Hashtable ht)
    {
        if (nodes.NodeType == XmlNodeType.Element)
        {
            XmlAttributeCollection attribts = nodes.Attributes;
            if (attribts.Count > 0)
            {
                foreach (XmlAttribute item in nodes.Attributes)
                {
                    ht.Add(item.Name, item.Value);
                }
            }

        }
    }
    /// <summary>
    /// 将对象转换成xml文件
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="path"></param>
    public static void Obj2Xml(Object obj, string path)
    {
        XmlSerializer ser = new XmlSerializer(obj.GetType());
        Stream st = new FileStream(path, FileMode.Create, FileAccess.Write);
        ser.Serialize(st, obj);
        st.Close();
    }
    /// <summary>
    /// 将xml文件转换成对象
    /// </summary>
    /// <param name="path"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    public static Object Xml2Obj(string path, Type type)
    {
        XmlSerializer ser = new XmlSerializer(type);
        //Stream用于提供字节序列的一般视图,这里将打开一个xml文件  
        Stream file = new FileStream(path, FileMode.Open, FileAccess.Read);
        object o = ser.Deserialize(file);
        file.Close();
        return o;
    }
}