using Google.Protobuf;
public class Protobuffer 
{
    
    /// <summary>
    /// ���л�
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static byte[] Serialize(IMessage message)
    {
        return message.ToByteArray();
    }

    /// <summary>
    /// �����л�
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="packct"></param>
    /// <returns></returns>
    public static T DeSerialize<T>(byte[] packct) where T : IMessage, new()
    {
        IMessage message = new T();
        try
        {
            return (T)message.Descriptor.Parser.ParseFrom(packct);
        }
        catch (System.Exception e)
        {

            throw e;
        }
    }

}
