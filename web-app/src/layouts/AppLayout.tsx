import { Outlet, useLocation } from "react-router-dom"
import { Sidebar } from "../components/Sidebar"
import { Header } from "../components/Header"

export function AppLayout() {
    const location = useLocation()
    return (
        <div className="min-h-screen flex bg-background text-gray-900">
            <Sidebar />

            <div className="flex-1 flex flex-col">
                <Header title={getTitleByPath(location.pathname)} />

                <main className="flex-1 p-6 overflow-y-auto">
                    <Outlet />
                </main>
            </div>
        </div>
    )
}

function getTitleByPath(path: string) {
    if (path.startsWith("/categories")) return "Categories"
    return "Dashboard"
}
