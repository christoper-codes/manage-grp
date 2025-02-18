
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
]

export default MiniSideIcons;
