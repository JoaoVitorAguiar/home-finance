export function Header({ title }: { title: string }) {
    return (
        <header className="h-16 bg-card border-b border-border flex items-center justify-between px-6">
            <h1 className="text-xl font-semibold tracking-tight">
                {title}
            </h1>
        </header>
    )
}
