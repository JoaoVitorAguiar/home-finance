import { useEffect, useState } from "react"
import { ReportsService } from "@/services/reports.service"
import type { TotalsByCategoryResponse, TotalsByPersonResponse } from "@/types/report"
import { formatCurrency } from "@/lib/format"
import { ExpensesByCategoryPie } from "@/components/charts/ExpensesByCategoryPie"


export function Dashboard() {
    const [personReport, setPersonReport] = useState<TotalsByPersonResponse | null>(null)
    const [categoryReport, setCategoryReport] = useState<TotalsByCategoryResponse | null>(null)

    const [loading, setLoading] = useState(true)

    useEffect(() => {
        async function load() {
            try {
                setLoading(true)
                const personData = await ReportsService.getTotalsByPerson()
                const categoryData = await ReportsService.getTotalsByCategory()

                setPersonReport(personData)
                setCategoryReport(categoryData)
            } finally {
                setLoading(false)
            }
        }

        load()
    }, [])

    if (loading) return <div className="text-muted-foreground">Loading dashboard...</div>
    if (!personReport) return null

    return (
        <div className="">

            <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
                <div className="rounded-xl p-5 bg-green-600 text-white shadow">
                    <p className="text-sm opacity-90">Income</p>
                    <p className="text-2xl font-semibold">
                        {formatCurrency(personReport.totalIncome)}
                    </p>
                </div>

                <div className="rounded-xl p-5 bg-red-500 text-white shadow">
                    <p className="text-sm opacity-90">Expenses</p>
                    <p className="text-2xl font-semibold">
                        {formatCurrency(personReport.totalExpense)}
                    </p>
                </div>

                <div className="rounded-xl p-5 bg-blue-600 text-white shadow">
                    <p className="text-sm opacity-90">Balance</p>
                    <p className="text-2xl font-semibold">
                        {formatCurrency(personReport.balance)}
                    </p>
                </div>
            </div>

            <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">

                <div className="bg-card border rounded-xl p-5">
                    <h3 className="font-semibold mb-4">Totals by person</h3>

                    <div className="space-y-3 max-h-105 overflow-y-auto pr-2">
                        {personReport.items.map(p => (
                            <div
                                key={p.personId}
                                className="flex items-center justify-between border rounded-lg p-3"
                            >
                                <div>
                                    <p className="font-medium">{p.personName}</p>
                                    <p className="text-sm text-muted-foreground">
                                        Income: {formatCurrency(p.totalIncome)} •{" "}
                                        Expenses: {formatCurrency(p.totalExpense)}
                                    </p>
                                </div>

                                <div
                                    className={`font-semibold ${p.balance >= 0 ? "text-green-600" : "text-red-600"
                                        }`}
                                >
                                    {formatCurrency(p.balance)}
                                </div>
                            </div>
                        ))}
                    </div>
                </div>

                <div className="bg-card border rounded-xl p-7 flex flex-col items-start justify-between">
                    <h3 className="font-semibold mb-4">Expenses by category</h3>

                    {categoryReport ? (
                        <ExpensesByCategoryPie items={categoryReport.items} />
                    ) : (
                        <div className="flex items-center justify-center h-72 text-muted-foreground">
                            Loading chart...
                        </div>
                    )}
                </div>
            </div>
        </div>
    )
}
