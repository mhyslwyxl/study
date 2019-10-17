<%--
  Created by IntelliJ IDEA.
  User: sdlgy
  Date: 2019-10-17
  Time: 10:12
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@page import="java.io.*" %>
<html>
<head>
    <title>获取文件属性示例</title>
</head>
<body>
<div>
    <%
        File f1 = new File("E:\\美和易思\\个人资料\\高效演讲", "高效演讲_攀登.txt");
        File f2 = new File("E:\\temp\\abc.doc");
    %>
    <p>文件[高效演讲_攀登.txt]是可读的吗？</p>
    <%=f1.canRead()%>
    <br/>
    <p>文件[高效演讲_攀登.txt] 的长度：</p>
    <%=f1.length()%>字节
    <br/>
    <p>文件[abc.doc 是目录吗？</p>
    <%=f2.isDirectory()%>
    <br/>
    <p>文件[高效演讲_攀登.txt]的父目录是:</p>
    <%=f1.getParent()%>
    <br/>
    <p>abc.doc的绝对路径是：</p>
    <%=f2.getAbsolutePath()%>
</div>
</body>
</html>
