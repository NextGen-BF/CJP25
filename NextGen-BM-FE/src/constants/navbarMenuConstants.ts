import { navSubMenuProps } from "../components/Navbar/NavigationSubMenu";

export const navbarMenuProps:navSubMenuProps[]=[
    {
        groupTitle: 'Requests',
        groupLinks: 
        [{
            link: "/create/request",
            title: "Create Request"
        },
        {
            link: "/requests",
            title: "Requests List"
        },
        {
            link: "/request",
            title: "Request Details"
        },]
    },
    {
        groupTitle: 'Payments',
        groupLinks: 
        [{
            link: "/payment",
            title: "Payment"
        },
        {
            link: "/property/fees",
            title: "Property Fees"
        },
        {
            link: "/create/propertyexpense",
            title: "Create Property Expense"   
        },
        {
            link: "/create/propertypayments",
            title: "Create Property Payments"
        },
    ]
    },
    {
        groupTitle: 'Properties',
        groupLinks: 
        [{
            link: "/properties",
            title: "Properties List"
        },
        {
            link: "/property",
            title: "Property Details"
        },
        {
            link: "/create/property",
            title: "Create property"
        },
        {
            link: "/property/residents",
            title: "Property Residents"
        }]
    },
    {
        groupTitle: 'Building',
        groupLinks: 
        [{
            link: "/building",
            title: "Building Details"
        },
        {
            link: "/create/building",
            title: "Create Building"
        },
        {
            link: "/buildings",
            title: "Buildings List"
        },
        {
            link: "/building/expenses",
            title: "Building Expenses"
        }]
    },
];
