<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="materielmanager.aspx.cs" Inherits="QuoteSystem.QSViews.materielmanager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<body>
    <div class="row">
    <div class="col-md-12">
        <div class="portlet">
            <div class="portlet-title">
                <div class="caption">
                    物料数据维护2
                </div>
                <div class="row">
					<form id="fileupload" action="../../assets/global/plugins/jquery-file-upload/server/php/" method="POST" enctype="multipart/form-data">
						<!-- The fileupload-buttonbar contains buttons to add/delete files and start/cancel the upload -->
						<div class="row fileupload-buttonbar">
							<div class="col-lg-7">
								<!-- The fileinput-button span is used to style the file input field as button -->
								<span class="btn green fileinput-button">
								<i class="fa fa-plus"></i>
								<span>
								123
								</span>
								<input type="file" name="files[]" multiple="">
								</span>
								<button type="submit" class="btn blue start" runat="server" OnClick="Unnamed_Click" >
								<i class="fa fa-upload"></i>
								<span>
								Start upload </span>
								</button>
							</div>
							<!-- The global progress information -->
							<div class="col-lg-5 fileupload-progress fade">
								<!-- The global progress bar -->
								<div class="progress progress-striped active" role="progressbar" aria-valuemin="0" aria-valuemax="100">
									<div class="progress-bar progress-bar-success" style="width:0%;">
									</div>
								</div>
								<!-- The extended global progress information -->
								<div class="progress-extended">
									 &nbsp;
								</div>
							</div>
						</div>
						<!-- The table listing the files available for upload/download -->
						<table role="presentation" class="table table-striped clearfix">
						<tbody class="files">
						</tbody>
						</table>
					</form>
                </div>
                <div class="tools">
                    <a href="javascript:;" class="collapse">
                    </a>
                    <a href="#" data-toggle="modal" class="config">
                    </a>
                    <a href="javascript:;" class="reload">
                    </a>
                </div>
            </div>
            <div class="portlet-body">

                <div class="table-container">
                    <table class="table table-striped table-bordered table-hover" id="materielTable" runat="server">
                        <thead>
                            <tr role="row" class="heading">
                                <th width="10%">
                                    物料号
                                </th>
                                <th width="35%">
                                    物料描述
                                </th>
                                <th width="5%">
                                    单位
                                </th>
                                <th width="25%">
                                    品牌
                                </th>
                                <th width="20%">
                                    不含税单价
                                </th>
                                <th>
                                </th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr role="row">
                                <td>
                                    10001
                                </td>
                                <td>
                                    XXXXX
                                </td>
                                <td>
                                    XXXXX
                                </td>
                                <td>
                                    XXXXX
                                </td>
                                <td>
                                    XXXXX
                                </td>
                                <td>
                                    <div class="">
                                        <button class="btn btn-xs blue btn-circle"><i class="fa fa-edit"></i></button>
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                
            </div>
        </div>
    </div>
</div>
</body>
</html>
