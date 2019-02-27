<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="Aras.Print" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
  <title>Print</title>

    <meta name="viewport" content="width=device-width, initial-scale=1" />

    
    
    <link href="css/bootstrap.css" rel="stylesheet" />

    <link href="css/styleee.css" rel="stylesheet" />
  <style>

      @media print {
        @page {
          size: 80mm 350mm;
          margin: 0;
          margin-right:-15px;
          
        }

    }
    
    p{
        margin:0px;
    }
    .fonts{
        font-size:2rem;
    }
    
  </style>

</head>
<body>

    <form id="form1"  runat="server">
        <section class="sheet fonts">
            <div class="row">
                <div class="text-center col-8">
                    <h5 class="p-0" style="font-size: 3rem;">علو‌‌ة ئاراس</h5>
                    <p>بۆ فرۆشتنی ماسێ زیندوو و مردو</p>

                    <p>ناونیشان /هەولێر </p>

                </div>
            </div>
            <br />
            <label>Select an dawd Printer: Select an installed Printer:</label>
            

            <br />
        </section>



        <button onclick="print();">Print Now...</button>

    </form>
</body>
</html>