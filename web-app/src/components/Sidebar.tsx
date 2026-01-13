import { NavLink } from "react-router-dom"

const menu = [
    { label: "Dashboard", path: "/", icon: "🏠" },
    { label: "Transactions", path: "/transactions", icon: "💳" },
    { label: "People", path: "/people", icon: "👥" },
    { label: "Categories", path: "/categories", icon: "🗂️" },
]

export function Sidebar() {
    return (
        <aside className="w-64 bg-[#020617] text-[#E5E7EB] flex flex-col border-r border-[#020617]">
            <div className="h-16 flex items-center gap-3 px-6 text-lg font-semibold border-b border-white/10 tracking-tight">
                <span className="text-2xl">🏠</span>
                <div className="leading-tight">
                    <div>Home Finance</div>
                    <div className="text-xs text-white/50">Household finance control</div>
                </div>
            </div>

            <nav className="flex-1 px-3 py-4 space-y-1">
                {menu.map(item => (
                    <NavLink
                        key={item.path}
                        to={item.path}
                        end
                        className={({ isActive }) =>
                            `group flex items-center gap-3 px-3 py-2.5 rounded-md text-sm font-medium transition-all
                            ${isActive
                                ? "bg-[#2563EB] text-white shadow"
                                : "text-white/80 hover:bg-[#1E293B] hover:text-white"
                            }`
                        }
                    >
                        <span className="w-8 h-8 flex items-center justify-center rounded-md bg-white/10 group-hover:bg-white/20 transition">
                            {item.icon}
                        </span>

                        <span>{item.label}</span>
                    </NavLink>
                ))}
            </nav>
        </aside>
    )
}
