# RocketBlogAPI

Blog system using RocketDirectory.

## SQL Index
Sort Index is required for "publisheddate":
```
	<sqlindex list="true">
		<genxml>
			<systemkey>rocketblogapi</systemkey>
			<ref>publisheddate</ref>
			<xpath>genxml/textbox/publisheddate</xpath>
			<typecode>rocketblogapiART</typecode>
		</genxml>
	</sqlindex>
```

The admin setup as:
```
sqlorderby-publisheddate | order by publisheddate.GUIDKey desc
```
Articel Search Filter

```
and (
isnull(articlename.GUIDKey,'') like '%{searchtext}%'
or isnull([XMLData].value('(genxml/textbox/articleref)[1]','nvarchar(max)'),'') like '%{searchtext}%'
or isnull([XMLData].value('(genxml/lang/genxml/textbox/articlekeywords)[1]','nvarchar(max)'),'') like '%{searchtext}%'
or isnull(publisheddate.GUIDKey,'') like '%{searchtext}%'
)
```