#region 导出Excel
    protected void Button1_Click(object sender, EventArgs e)
    {
        ExportDataGrid( "online/ms-excel", "111.xls" );
    }
    private void ExportDataGrid(string FileType, string FileName)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "utf-8";
        Response.AppendHeader( "Content-Disposition", "attachment;filename=FileFlow.xls" );
        Response.ContentEncoding = System.Text. Encoding.GetEncoding("utf-8" );
        Response.ContentType = "application/ms-excel";
        this.EnableViewState = false ;
        System.IO. StringWriter oStringWriter = new System.IO.StringWriter();
        System.Web.UI. HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
        this.GridView1.RenderControl(oHtmlTextWriter);
        Response.Write(oStringWriter.ToString());
        Response.End();
    }
    #endregion

代码结构有些乱，可以将数据层进行提取分层。比如AddUser.aspx进行了重构，其他部分功能类似，就不重复操作了
