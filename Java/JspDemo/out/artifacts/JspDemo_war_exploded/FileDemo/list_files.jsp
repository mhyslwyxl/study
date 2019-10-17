<%--
  Created by IntelliJ IDEA.
  User: sdlgy
  Date: 2019-10-17
  Time: 10:25
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
    File dir = new File("E:\\soursecode\\vue\\mint-ui");
    File files[] = dir.listFiles();
%>
<hr>
目录列表：<br>
<%
    for (File file : files) {
        if (file.isDirectory()) {
            out.print("<br/>目录--" + file.toString());
        }
    }
%>
<hr>
文件列表：<br>
<%
    for (File file : files) {
        if (!file.isDirectory()) {
            out.print("<br>文件--" + file.toString());
        }
    }
%>
</body>
</html>
