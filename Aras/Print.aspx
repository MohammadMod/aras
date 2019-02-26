<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="Aras.Print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
  <title>Print</title>

    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/3.0.3/normalize.css"/>
    <link rel="stylesheet" href="../paper.css" />
    <link href="css/bootstrap.css" rel="stylesheet" />

  <style>
    @page { size: 70mm 150mm } /* output size */
    body.receipt .sheet { width: 300mm; height: 100mm } /* sheet size */
    @media print { body.receipt { width: 300mm } } /* fix for Chrome */
  </style>

</head>
<body>
    
    <form id="form1" runat="server">
    <section class="sheet padding-10mm" style="font-size:15px">
    .............................................................................
        <div class="row">
        <div class="text-center col">
        <label>Select an dawd Printer: Select an installed Printer:</label>
        </div>
    </div>
              <br />
        <label>Select an dawd Printer: Select an installed Printer:</label>
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
