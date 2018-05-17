USE [NavMenuDB]
GO
SET IDENTITY_INSERT [dbo].[NavigationMenu] ON 

GO
INSERT [dbo].[NavigationMenu] ([LinkId], [LinkLevel], [Linktype], [ParentLink], [LinkOrder], [LinkText], [HasChildren], [Class]) VALUES (1, 1, N'LINK', 0, 0, N'MENU A', 1, N'4|grid no-margin')
GO
INSERT [dbo].[NavigationMenu] ([LinkId], [LinkLevel], [Linktype], [ParentLink], [LinkOrder], [LinkText], [HasChildren], [Class]) VALUES (2, 1, N'LINK', 0, 1, N'MENU B', 1, N'4|inline-list')
GO
INSERT [dbo].[NavigationMenu] ([LinkId], [LinkLevel], [Linktype], [ParentLink], [LinkOrder], [LinkText], [HasChildren], [Class]) VALUES (10002, 2, N'TITLE', 1, 0, N'TITLE A', 1, N'text-shadow')
GO
INSERT [dbo].[NavigationMenu] ([LinkId], [LinkLevel], [Linktype], [ParentLink], [LinkOrder], [LinkText], [HasChildren], [Class]) VALUES (10003, 2, N'TITLE', 1, 1, N'TITLE B', 1, N'text-shadow')
GO
INSERT [dbo].[NavigationMenu] ([LinkId], [LinkLevel], [Linktype], [ParentLink], [LinkOrder], [LinkText], [HasChildren], [Class]) VALUES (10004, 2, N'TITLE', 1, 2, N'TITLE C', 1, N'text-shadow')
GO
INSERT [dbo].[NavigationMenu] ([LinkId], [LinkLevel], [Linktype], [ParentLink], [LinkOrder], [LinkText], [HasChildren], [Class]) VALUES (10006, 2, N'http://www.google.ca', 1, 0, N'title a menu 1', 1, N'#')
GO
INSERT [dbo].[NavigationMenu] ([LinkId], [LinkLevel], [Linktype], [ParentLink], [LinkOrder], [LinkText], [HasChildren], [Class]) VALUES (10007, 2, N'http://www.google.ca', 1, 0, N'title a menu 2', 1, N'#')
GO
INSERT [dbo].[NavigationMenu] ([LinkId], [LinkLevel], [Linktype], [ParentLink], [LinkOrder], [LinkText], [HasChildren], [Class]) VALUES (10009, 2, N'http://www.google.ca', 1, 1, N'title b menu1', 1, N'#')
GO
INSERT [dbo].[NavigationMenu] ([LinkId], [LinkLevel], [Linktype], [ParentLink], [LinkOrder], [LinkText], [HasChildren], [Class]) VALUES (10010, 2, N'http://www.google.ca', 1, 1, N'title b menu 2', 1, N'#')
GO
INSERT [dbo].[NavigationMenu] ([LinkId], [LinkLevel], [Linktype], [ParentLink], [LinkOrder], [LinkText], [HasChildren], [Class]) VALUES (50004, 2, N'http://www.google.ca', 2, 1, N'menu b link 1', 1, N'#')
GO
INSERT [dbo].[NavigationMenu] ([LinkId], [LinkLevel], [Linktype], [ParentLink], [LinkOrder], [LinkText], [HasChildren], [Class]) VALUES (50005, 2, N'http://www.google.ca', 1, 2, N'title c menu 1', 1, N'#')
GO
INSERT [dbo].[NavigationMenu] ([LinkId], [LinkLevel], [Linktype], [ParentLink], [LinkOrder], [LinkText], [HasChildren], [Class]) VALUES (50007, 1, N'http://www.google.ca', 2, 2, N'menu b link 2', 1, N'#')
GO
SET IDENTITY_INSERT [dbo].[NavigationMenu] OFF
GO
