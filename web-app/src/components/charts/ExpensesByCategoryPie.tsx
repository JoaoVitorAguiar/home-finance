import { PieChart, Pie, Cell, Tooltip, ResponsiveContainer } from "recharts"
import type { CategoryTotalsItem } from "@/types/report"
import { formatCurrency } from "@/lib/format"

const COLORS = [
    "#ef4444", "#f97316", "#eab308", "#22c55e", "#06b6d4",
    "#3b82f6", "#8b5cf6", "#ec4899", "#14b8a6", "#64748b"
]

type Props = {
    items: CategoryTotalsItem[]
}

export function ExpensesByCategoryPie({ items }: Props) {
    const data = items
        .filter(i => i.totalExpense > 0)
        .map(i => ({
            name: i.categoryDescription,
            value: i.totalExpense,
        }))

    if (data.length === 0) {
        return (
            <div className="flex items-center justify-center h-full text-muted-foreground text-sm">
                No expense data
            </div>
        )
    }

    return (
        <ResponsiveContainer width="100%" height={300}>
            <PieChart>
                <Pie
                    data={data}
                    dataKey="value"
                    nameKey="name"
                    cx="50%"
                    cy="50%"
                    outerRadius={110}
                    label
                >
                    {data.map((_, index) => (
                        <Cell key={index} fill={COLORS[index % COLORS.length]} />
                    ))}
                </Pie>

                <Tooltip
                    formatter={(value) => formatCurrency(Number(value ?? 0))}
                />
            </PieChart>
        </ResponsiveContainer>
    )
}
