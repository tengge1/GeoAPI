using GeoAPI.Operation.Buffer;

namespace GeoAPI.Operation.Buffer
{
    /// <summary>
    /// ���ڿ��ƻ������������̵Ĳ�������Ľӿ�
    /// <para>
    /// ����������ƣ�
    /// <list type="Bullet">
    /// <item>���޶Σ�Բ�����ƾ��ȣ�</item>
    /// <item>��ñ���</item>
    /// <item>������ʽ</item>
    /// <item>б������</item>
    /// <item>�������Ƿ��ǵ����</item>
    /// </list>
    /// </para>
    /// </summary>
    public interface IBufferParameters
    {
        ///<summary>
        /// ��ȡ/���ý�Ҫʹ�õ����޶���
        ///</summary>
        /// <remarks>
        /// QuadrantSegments�����ڽ��ƽǶ�Բ�ǵ��߶�����
        /// <list type="Table">
        /// <item>qs &gt;>= 1</item><description>������Բ�εģ�qs��ʾ���ڽ����ķ�֮һȦ�Ķ�����</description>
        /// <item>qs = 0</item><description>������б���</description>
        /// <item>qs &lt; 0</item><description>���ӱ����ԣ�qs��ֵ��ʾб�Ǳ�������Ϊ<c> mitreLimit = | qs | </ c></description>
        /// </list>
        /// </remarks>
        int QuadrantSegments { get; set; }

        ///<summary>
        /// ��ȡ/�������ɵĻ������Ķ�ñ��ʽ��
        ///</summary>
        /// <remarks>
        /// <para>
        /// ֧�ֵ���ʽ��<see cref ="GeoAPI.Operation.Buffer.EndCapStyle.Round"/>��<see cref ="GeoAPI.Operation.Buffer.EndCapStyle.Flat"/>��<see cref ="GeoAPI.Operation��Buffer.EndCapStyle.Square"/>��
        /// </para>
        /// <para>Ĭ��ֵΪ<see cref ="GeoAPI.Operation.Buffer.EndCapStyle.Round"/>��</para>
        /// </remarks>
        EndCapStyle EndCapStyle { get; set; }

        ///<summary>
        /// ��ȡ/�����߶�֮����ⲿ�����䣩�ǵ�������ʽ��
        ///</summary>
        /// <remarks>
        /// <para>�����ֵΪ<see cref =��GeoAPI.Operation.Buffer.JoinStyle.Round��/>������Ĭ��ֵ����<see cref =��GeoAPI.Operation.Buffer.JoinStyle.Mitre��/>��<see cref =��GeoAPI.Operation.Buffer.JoinStyle.Bevel��/></para>
        /// </remarks>
        JoinStyle JoinStyle { get; set; }

        ///<summary>
        /// �������ڷǳ����������б�Ǳȵļ��ޡ�
        ///</summary>
        /// <remarks>
        /// <para>
        /// б�Ǳ��Ǵ�ƫ�Ľ�ƫ�ƽǵ��յ�ľ���ı�ֵ�� �������߶�������ཻʱ��б�����ӽ�ԶԶ����ԭʼ���Ρ� �������ڼ�������½�����Զ����Ϊ�˷�ֹ������ļ�����״��б����������������ӽǵ���󳤶ȡ� �Ƕȳ������޵Ľ��佫����б��
        /// </para>
        /// </remarks>
        double MitreLimit { get; set; }

        /// <summary>
        /// ��ȡ�����ü��㻺�����Ƿ�Ӧ���ǵ���ġ� ���滺��������ÿ�������ߵ�һ�๹�ɡ�
        /// <para>
        /// ��ʹ�õ�һ���ɻ������ķ��ž�����
        /// <list type="Bullet">
        /// <item>���ľ����ʾ���</item>
        /// <item>�������ʾ�Ҳ�</item>
        /// </list>
        /// �㼸�εĵ��滺�����볣�滺������ͬ��
        /// </para><para>
        /// ���򻺳����Ķ˸���ʽ���Ǳ����ԣ�����ǿ�Ƶ�ͬ��<see cref ="GeoAPI.Operation.Buffer.EndCapStyle.Flat"/>��
        /// </para>
        /// </summary>
        bool IsSingleSided { get; set; }

        /// <summary>
        /// ��ȡ����������ȷ���򻯾��빫������ӣ���ʵ������򻯡� �򻯿�����߼��㻺���������ܡ� ͨ����������Ӧ����0.�������ɻ�������0.01��0.1֮���ֵ������ԽϺõľ��ȡ� ����ļ�ֵ�����������ر����֡�
        /// </summary>
        double SimplifyFactor { get; set; }
    }
}