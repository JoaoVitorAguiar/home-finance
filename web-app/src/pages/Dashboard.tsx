import { useEffect, useState } from "react"
import { ReportsService } from "@/services/reports.service"
import type { TotalsByPersonResponse } from "@/types/report"
import { formatCurrency } from "@/lib/format"


export function Dashboard() {
    const [report, setReport] = useState<TotalsByPersonResponse | null>(null)
    const [loading, setLoading] = useState(true)

    useEffect(() => {
        async function load() {
            try {
                setLoading(true)
                const data = await ReportsService.getTotalsByPerson()
                setReport(data)
            } finally {
                setLoading(false)
            }
        }

        load()
    }, [])

    if (loading) return <div className="text-muted-foreground">Loading dashboard...</div>
    if (!report) return null

    return (
        <div className="space-y-6">

            <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
                <div className="rounded-xl p-5 bg-green-600 text-white shadow">
                    <p className="text-sm opacity-90">Income</p>
                    <p className="text-2xl font-semibold">
                        {formatCurrency(report.totalIncome)}
                    </p>
                </div>

                <div className="rounded-xl p-5 bg-red-500 text-white shadow">
                    <p className="text-sm opacity-90">Expenses</p>
                    <p className="text-2xl font-semibold">
                        {formatCurrency(report.totalExpense)}
                    </p>
                </div>

                <div className="rounded-xl p-5 bg-blue-600 text-white shadow">
                    <p className="text-sm opacity-90">Balance</p>
                    <p className="text-2xl font-semibold">
                        {formatCurrency(report.balance)}
                    </p>
                </div>
            </div>

            <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">

                <div className="bg-card border rounded-xl p-5">
                    <h3 className="font-semibold mb-4">Totals by person</h3>

                    <div className="space-y-3 max-h-105 overflow-y-auto pr-2">
                        {report.items.map(p => (
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

                <div className="bg-card border rounded-xl p-5 flex items-center justify-center text-muted-foreground">

                </div>
            </div>
        </div>
    )
}
