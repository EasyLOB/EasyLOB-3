SELECT
    AspNetUsers.UserName,
    AspNetUsers.Email,
    AspNetRoles.Name,
    EasyLOBActivity.Name,
    EasyLOBActivityRole.Operations
FROM
    AspNetUsers
    LEFT JOIN AspNetUserRoles ON
        AspNetUserRoles.UserId = AspNetUsers.Id
    LEFT JOIN AspNetRoles ON
        AspNetRoles.Id = AspNetUserRoles.RoleId
    LEFT JOIN EasyLOBActivityRole ON
        EasyLOBActivityRole.RoleName = AspNetRoles.Name
    LEFT JOIN EasyLOBActivity ON
        EasyLOBActivity.Id = EasyLOBActivityRole.ActivityId
ORDER BY
    1,3,4
