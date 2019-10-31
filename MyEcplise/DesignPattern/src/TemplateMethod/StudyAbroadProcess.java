package TemplateMethod;

public class StudyAbroadProcess
{
	public static void main(String[] args)
 	{
		StudyAbroad tm = new StudyInAmerica();
		tm.TemplateMethod();
	}
}

// ������: ������ѧ
abstract class StudyAbroad {
	public void TemplateMethod() // ģ�巽��
	{
		LookingForSchool(); // ��ȡѧУ����
		ApplyForEnrol(); // ��ѧ����
		ApplyForPassport(); // ������˽�������ա��������͹�֤
		ApplyForVisa(); // ����ǩ֤
		ReadyGoAbroad(); // ��졢����Ʊ��׼����װ
		Arriving(); // �ִ�
	}

	public void ApplyForPassport() {
		System.out.println("��.������˽�������ա��������͹�֤��");
		System.out.println("  1����¼ȡ֪ͨ�顢���˻��ڲ������֤�򻧿����ڵع����������������˽�������պͳ�������");
		System.out.println("  2�����������֤�飬ѧ����ѧλ�ͳɼ���֤������֤�飬������ϵ��֤�����õ�����֤��");
	}

	public void ApplyForVisa() {
		System.out.println("��.����ǩ֤��");
		System.out.println("  1��׼��������⾳ǩ֤����ĸ������ϣ���������ѧ�����ɼ���������������֤�������˼���ͥ���롢�ʽ�ͲƲ�֤������ͥ��Ա�Ĺ�ϵ֤���ȣ�");
		System.out.println(
				"  2��������ѧ����פ��ʹ(��)�������뾳ǩ֤������ʱ�谴Ҫ����д�йر�񣬵ݽ������֤�����ϣ�����ǩ֤���еĹ���(����������Ӣ�������ô��)������ǩ֤ʱ��Ҫ��������ǰ��ʹ(��)�ݽ������ԡ�");
	}

	public void ReadyGoAbroad() {
		System.out.println("��.��졢����Ʊ��׼����װ��");
		System.out.println("  1�����������顢���߼��ͽ��ִ�Ⱦ�����磻");
		System.out.println("  2��ȷ����Ʊʱ�䡢�����ת���ص㡣");
	}

	public abstract void LookingForSchool();// ��ȡѧУ����

	public abstract void ApplyForEnrol(); // ��ѧ����

	public abstract void Arriving(); // �ִ�
}

// ��������: ������ѧ
class StudyInAmerica extends StudyAbroad {
	@Override
	public void LookingForSchool() {
		System.out.println("һ.��ȡѧУ�������ϣ�");
		System.out.println("  1������ѧ������ҵ����Ρ����á��Ļ������ͽ������ơ�ѧ��ˮƽ���н�Ϊȫ����˽⣻");
		System.out.println("  2��ȫ���˽�����չ���ѧУ�������������ʷ��ѧ�ѡ�ѧ�ơ�רҵ��ʦ���䱸����ѧ��ʩ��ѧ����λ��ѧ�������ȣ�");
		System.out.println("  3���˽��ѧУ��ס�ޡ���ͨ��ҽ�Ʊ��������Σ�");
		System.out.println("  4����ѧУ���й��Ƿ�����Ȩ������������ѧ�н鹫˾��");
		System.out.println("  5��������ѧǩ֤�����");
		System.out.println("  6���ù������Ƿ�������ѧ���Ϸ��򹤣�");
		System.out.println("  8����ҵ֮��ɷ�����");
		System.out.println("  9����ƾ�Ƿ��ܵ��ҹ��Ͽɣ�");
	}

	@Override
	public void ApplyForEnrol() {
		System.out.println("��.��ѧ���룺");
		System.out.println("  1����д������");
		System.out.println("  2��������������ѧ��֤���������ѧϰ�ɼ������Ƽ��š����˼������и�����˼���Կ��Գɼ��������ϼ����������ѧУ��");
		System.out.println("  3��Ϊ�˸�ǩ֤�������г�ԣ��ʱ�䣬����Խ������Խ�ã�һ����ǰ1��ͱȽϴ��ݡ�");
	}

	@Override
	public void Arriving() {
		System.out.println("��.�ִ�Ŀ��ѧУ��");
		System.out.println("  1������ס�ޣ�");
		System.out.println("  2���˽�У԰���ܱ߻�����");
	}
}