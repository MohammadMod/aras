<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="Aras.Print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
    <title></title>
      <meta charset="utf-8">
  <title>receipt</title>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/3.0.3/normalize.css">
  <link rel="stylesheet" href="../paper.css">
  <style>
    @page { size: 70mm 150mm } /* output size */
    body.receipt .sheet { width: 300mm; height: 100mm } /* sheet size */
    @media print { body.receipt { width: 300mm } } /* fix for Chrome */
  </style>
</head>
<body class="receipt">
    <form id="form1" runat="server">
   
  
  <section class="sheet padding-10mm" style="font-size:15px">
    .............................................................................
              <br />
        <label>Select an installed Printer: Select an installed Printer:</label>
        <br />
        <label >ناوى جيشتخان: Select an installed Printer:</label>
      <br />
    <label >ناوى جيشتخانه</label>

        <br />
  </section>
  
    
       
        <button onclick="print();">Print Now...</button>

    </form>
</body>
</html>
