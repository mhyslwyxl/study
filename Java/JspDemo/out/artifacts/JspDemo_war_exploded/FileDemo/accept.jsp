<%--
  Created by IntelliJ IDEA.
  User: sdlgy
  Date: 2019-10-17
  Time: 10:52
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<%@page import="java.io.*" %>
<html>
<head>
    <title>Title</title>
</head>
<body>
<%
    try
    {
        InputStream in=request.getInputStream();
        File dir=new File("e:/temp/l000");
        dir.mkdir();
        File f=new File(dir,"B.txt");
        FileOutputStream o=new FileOutputStream(f);
        byte b[]=new byte[1000];
        int n;
        while((n=in.read(b))!=-1)
            o.write(b,0,n);
        in.close();
        out.print ("文件已上传");
    }
    catch(IOException e)
    {
        out.print("上传失败"+e);
    }
%>
</body>
</html>
