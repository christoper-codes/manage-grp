
export interface minisidebar {
    icon?: string;
    id?:number;
    tooltip?:string
}
const MiniSideIcons: minisidebar[] = [
    {
        icon: 'layers-line-duotone',
        tooltip:'MEMBER',
        id: 1
    },
    {
        icon: 'notes-line-duotone',
        tooltip:'ADMIN',
        id: 2,
    },
    {
        icon: 'palette-round-line-duotone',
        tooltip:'SUPER_ADMIN',
        id: 3
    },
    {
        icon:'align-vertical-spacing-broken',
        tooltip:'GENERAL',
        id: 4
    },
    {
        icon:'chart-line-duotone',
        tooltip:'GENERAL',
        id: 5
    },
    {
        icon:'widget-6-line-duotone',
        tooltip:'GENERAL',
        id: 6
    },
    {
        icon:'lock-keyhole-line-duotone',
        tooltip:'GENERAL',
        id: 7
    },
    {
        icon:'mirror-left-line-duotone',
        tooltip:'GENERAL',
        id: 8
    }
]

export default MiniSideIcons;
