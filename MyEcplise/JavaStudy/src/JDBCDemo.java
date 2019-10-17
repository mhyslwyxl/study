import java.sql.*;

public class JDBCDemo {
	// MySQL 8.0 以下版本 - JDBC 驱动名及数据库 URL
	// static final String JDBC_DRIVER = "com.mysql.jdbc.Driver";
	// static final String DB_URL = "jdbc:mysql://localhost:3306/RUNOOB";

	// MySQL 8.0 以上版本 - JDBC 驱动名及数据库 URL
	static final String JDBC_DRIVER = "com.mysql.cj.jdbc.Driver";
	static final String DB_URL = "jdbc:mysql://localhost:3306/mhysoa?useSSL=false&serverTimezone=UTC";

	// 数据库的用户名与密码，需要根据自己的设置
	static final String USER = "root";
	static final String PASS = "123456";

	static void update() {
		Connection conn = null;
		Statement stmt = null;
		try {
			Class.forName(JDBC_DRIVER);
			conn = DriverManager.getConnection(DB_URL, USER, PASS);
			stmt = conn.createStatement();
			String sql = "insert into student(name, age) values('aabb',15)";
			int rowCount = stmt.executeUpdate(sql);
			if (rowCount > 0) {
				System.out.println("更新成功！");
			} else {
				System.out.println("更新失败！");
			}
			stmt.close();
			conn.close();
		} catch (SQLException se) {
			// 处理 JDBC 错误
			se.printStackTrace();
		} catch (Exception e) {
			// 处理 Class.forName 错误
			e.printStackTrace();
		} finally {
			// 关闭资源
			try {
				if (stmt != null)
					stmt.close();
			} catch (SQLException se2) {
			} // 什么都不做
			try {
				if (conn != null)
					conn.close();
			} catch (SQLException se) {
				se.printStackTrace();
			}
		}
		System.out.println("update run ok!");
	}

	static void runProc() {
		String returnCode = "";
		String returnMsg = "";
		Connection conn = null;
		CallableStatement cstm = null;
		try {
			// 注册 JDBC 驱动
			Class.forName(JDBC_DRIVER);

			// 打开链接
			System.out.println("连接数据库...");
			conn = DriverManager.getConnection(DB_URL, USER, PASS);
			String sql = "{CALL add_two(?,?,?)}";
			cstm = conn.prepareCall(sql);
			cstm.setInt(1, 123); // 存储过程输入参数
			cstm.setInt(2, 400); // 存储过程输入参数
			//cstm.setInt(3, 400);
			cstm.registerOutParameter(3, Types.INTEGER); // 设置返回值类型 即返回值
			cstm.execute(); // 执行存储过程
			returnCode = cstm.getString(3);
			cstm.close();
			conn.close();
			System.out.println(returnCode);
		} catch (SQLException se) {
			// 处理 JDBC 错误
			se.printStackTrace();
		} catch (Exception e) {
			// 处理 Class.forName 错误
			e.printStackTrace();
		} finally {
			// 关闭资源
			try {
				if (cstm != null)
					cstm.close();
			} catch (SQLException se2) {
			} // 什么都不做
			try {
				if (conn != null)
					conn.close();
			} catch (SQLException se) {
				se.printStackTrace();
			}
		}
	}

	public static void main(String[] args) {
		// update();
		runProc();
		return;
//		Connection conn = null;
//		Statement stmt = null;
//		try {
//			// 注册 JDBC 驱动
//			Class.forName(JDBC_DRIVER);
//
//			// 打开链接
//			System.out.println("连接数据库...");
//			conn = DriverManager.getConnection(DB_URL, USER, PASS);
//
//			// 执行查询
//			System.out.println(" 实例化Menu对象...");
//			stmt = conn.createStatement();
//			String sql;
//			sql = "SELECT id, name, code FROM system_menu";
//			ResultSet rs = stmt.executeQuery(sql);
//
//			// 展开结果集数据库
//			while (rs.next()) {
//				// 通过字段检索
//				int id = rs.getInt("id");
//				String name = rs.getString("name");
//				String code = rs.getString("code");
//
//				// 输出数据
//				System.out.print("ID: " + id);
//				System.out.print(", 站点名称: " + name);
//				System.out.print(", 站点 Code: " + code);
//				System.out.print("\n");
//			}
//			// 完成后关闭
//			rs.close();
//			stmt.close();
//			conn.close();
//		} catch (SQLException se) {
//			// 处理 JDBC 错误
//			se.printStackTrace();
//		} catch (Exception e) {
//			// 处理 Class.forName 错误
//			e.printStackTrace();
//		} finally {
//			// 关闭资源
//			try {
//				if (stmt != null)
//					stmt.close();
//			} catch (SQLException se2) {
//			} // 什么都不做
//			try {
//				if (conn != null)
//					conn.close();
//			} catch (SQLException se) {
//				se.printStackTrace();
//			}
//		}
//		System.out.println("Goodbye!");
	}
}
