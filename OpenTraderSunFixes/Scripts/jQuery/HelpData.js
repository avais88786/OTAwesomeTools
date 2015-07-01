var helpDataArray = [];

helpDataArray.push("<h3 style=\"margin-top:0px;text-align:center\" >Select 'Fix Type' as 'SUN' below for fixes required in SUN:</h3>"
                 + "<h4>XML will be generated based on selected transaction and options. This XML need to be supplied to the concerned BA who will upload it to the Sun Systems.</h4><br/><br/>" 
                 + "<h3 style=\"margin-top:0px;text-align:center;\">Select 'Fix Type' as 'Trader' below for fixes required in Trader:</h3>"
                 + "SQL Script will be generated based on selected transactions. This script should either be committed to Trunk or supplied to SOC as a patch."
                 + "<b>Before That,</b>based on this SQL Script, an XML would be required that needs to be given to the BA who will upload it " 
                 + "and verify if <b>the Generated Script would be inserting correct values once executed on the correct environment.</b><br/>"
                 + "After generating the script you will get an option to generate an XML based on the generated script.");



helpDataArray.push("<h3 style=\"margin-top:0px;text-align:center\"> Change in Premium Values:</h3>"
                 + "Accounts Department usually supply a spreadsheet where all corrections to premiums required are specified.<br />"
                 + "For the table below, a row displayed for each transaction is kept at its best to match the rows within that spreadsheet.<br />"
                 + "Match the cell values within the spreadsheet to cell values within the below table for <b>same transaction and same column(s)</b> and click 'GenerateFix'<br />"
                 + "Once you hit the button, on the next page you would get an XML/Script with required changes.<br />");


helpDataArray.push("<h3 style=\"margin-top:0px;text-align:center\">Decide the Type of Transaction:</h3>"
                 + "Original : XML will be generated based on Original Premium Values of Selected Transaction<br />"
                 + "Contra&nbsp;&nbsp;: XML will be generated with Contra Premium Values of Selected Transaction<br />"
                 + "See <a href=\"\">SOC-XX</a> for a sample JIRA task.<br /><br />"
                 + "<b style=\"color:red;\">Applicable only for Sun Fixes</b>");

helpDataArray.push("<h3 style=\"margin-top:0px;text-align:center\">Decide the Business Unit:</h3>"
                 + "Test : This should be the first instance of generated XML. BA will upload this 'Test' version and will confirm if XML is correct.<br/>"
                 + "Live : After a Test has been uploaded and if it was successful (BA will notify), a 'Live' version should be generated with <b>exactly same</b> options as Test"
                 + " (apart from Transaction Reference Append Char)<br/>"
                 + "The 'Convert Test XMLs to Live' link at the top of the page would do this work for you. Using it is pretty straight forward.<br/><br/>"
                 + "<b style=\"color:red;\">Applicable only for Sun Fixes</b>");

helpDataArray.push("<h3 style=\"margin-top:0px;text-align:center\">Decide the Posting Date: (Either mentioned on the task or Confirm with the BA)</h3>"
                 + "The XML will have a tag '&lt;GeneralDescription1&gt;' which decides for which date this XML values are to be posted <br />"
                 + "Original : Date, the selected Transaction was processed (effective date) <br />"
                 + "This Month: Post XMLs for this month<br />"
                 + "See <a href=\"\">SOC-XX</a> for a sample JIRA task.<br /><br />"
                 + "<b style=\"color:red;\">Applicable only for Sun Fixes</b>");

helpDataArray.push("<h3 style=\"margin-top:0px;text-align:center\">Append Character to Transaction Reference:</h3>"
                 + "Once an XML for a Transaction has been uploaded, the tag &lt;TransactionReference&gt; from the generated XML will be saved in SUN <b>even if it is a test.</b> <br />"
                 + "This bit should be unique for each subsequent uploads of same transaction.<br />"
                 + "The next XML for the same transaction should have a new 'TransactionReference' value. <br />"
                 + "Type a unique single character every time you generate an XML for same transaction.<br /><br />"
                 + "<b style=\"color:red;\">Applicable only for Sun Fixes</b>");
