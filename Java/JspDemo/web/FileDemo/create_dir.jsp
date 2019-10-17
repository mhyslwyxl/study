<%--
  Created by IntelliJ IDEA.
  User: sdlgy
  Date: 2019-10-17
  Time: 10:20
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ page import="java.io.*" %>
<html>
<head>
    <title>Title</title>
</head>
<body>
<%
    File dir = new File("E:\\temp", "Students");
%>
在 e:\temp 下创建一个新的目录：student,<br>成功创建了吗？
<%=dir.mkdir()%>
<br/>
student 是目录吗？
<font color="red">
    <%=dir.isDirectory()%>
</font>
</body>
</html>
