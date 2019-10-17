<%--
  Created by IntelliJ IDEA.
  User: sdlgy
  Date: 2019-10-17
  Time: 10:38
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@ page import="java.io.*" %>
<html>
<head>
    <title>Title</title>
</head>
<body>
<%!
    class FileJsp implements FilenameFilter {
        String str = null;

        FileJsp(String s) {
            str = "." + s;
        }

        public boolean accept(File dir, String name) {
            return name.endsWith(str);
        }
    }
%>
<hr>
<%
    File dir = new File("E:\\MyStudy\\Java\\JspDemo\\web\\FileDemo");
    FileJsp fileJsp = new FileJsp("jsp");
    String files[] = dir.list(fileJsp);
    for (int i = 0; i < files.length; i++)
        out.print("<br>" + files[i]);

%>
<%
    File dir2 = new File("E:\\MyStudy\\Java\\JspDemo\\web\\FileDemo");
    File files2[] = dir2.listFiles();
    for (int i = 0; i < files2.length; i++)
        out.print("<br>" + files2[i].getName());
%>
</body>
</html>
