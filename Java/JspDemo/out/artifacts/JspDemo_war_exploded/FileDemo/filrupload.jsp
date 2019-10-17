<%--
  Created by IntelliJ IDEA.
  User: sdlgy
  Date: 2019-10-17
  Time: 10:51
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Title</title>
</head>
<body>
<P>选择要上传的文件：<br>
<form action="accept.jsp" method="post" engtype="multipart/form-data">
    <input type=File name="boy" size="38">
    <br>
    <input type="submit" name="g" value="提交">
</form>
</body>
</html>
