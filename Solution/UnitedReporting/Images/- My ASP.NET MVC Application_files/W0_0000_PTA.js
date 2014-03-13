function login(frm,target) {

var agt = navigator.userAgent.toLowerCase();
frm.appname.value ="microsoft";
frm.os.value = "window";

if (agt.indexOf("win") != -1) {frm.os.value = "window" ;} 
else if (agt.indexOf("mac") != -1) {frm.os.value = "mac" ;} 
else if (agt.indexOf("linux") != -1) {frm.os.value = "linux" ;} 
else if (agt.indexOf("x11") != -1) {frm.os.value = "x11" ;} 
else {frm.os.value = "unknown" ;}

if(agt.indexOf("microsoft") != -1) {frm.appname.value ="microsoft";} 
else if(agt.indexOf("msie") != -1) {frm.appname.value ="microsoft";}
else if(agt.indexOf("firefox") != -1) {frm.appname.value ="firefox";}
else if(agt.indexOf("safari") != -1) {frm.appname.value ="safari";}
else {frm.appname.value = "unknown" ;}

	
if(Trim(frm.rbwebuserid.value) == '')
{	alert("User ID is required.");
	frm.rbwebuserid.focus();
	return;
}
	
if(frm.rbwebpassword.value == '')
{	alert("Password is required.");
	frm.rbwebpassword.focus();
	return;
}
	
if (target == 1){ // new widnow
	var strPollUrl;
	winpos = "left=0,top=0";
	strPollUrl=  frm.action ; 
	strPollUrl=  strPollUrl + "?rbwebuserid=" + escape(Trim(frm.rbwebuserid.value)) + "&rbwebpassword=" + escape(frm.rbwebpassword.value) + "&appname=" + frm.appname.value + "&os=" + frm.os.value;
	winstyle="width=" + screen.availWidth + ",height=" +  screen.availHeight + ",status=1,toolbar=1,menubar=1,location=1,resizable=yes,scrollbars=1," + winpos;
	window.open(strPollUrl,'RBWeb',winstyle);
	return false;
	
}

else{	frm.submit();}

}

function Ltrim(strValue){
    while (strValue.length>0){
       if(strValue.charAt(0)==' '){
           strValue=strValue.substring(1,strValue.length);              
	   }
       else
          return strValue;	    
    }
	return strValue;
}

function Rtrim(strValue){
    while (strValue.length>0){
       if(strValue.charAt(strValue.length-1)==' '){
           strValue=strValue.substring(0,strValue.length-1);              
	   }
       else
           return strValue;	    
   }
   return strValue;
}


function Trim(strValue){
   strValue = Ltrim(strValue);
   strValue = Rtrim(strValue);
   return strValue;
}

