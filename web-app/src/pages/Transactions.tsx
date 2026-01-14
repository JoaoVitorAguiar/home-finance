import { useEffect, useMemo, useState } from "react"
import { Button } from "@/components/ui/button"
import {
    Dialog,
    DialogContent,
    DialogHeader,
    DialogTitle,
    DialogTrigger,
} from "@/components/ui/dialog"
import { Input } from "@/components/ui/input"
import { Label } from "@/components/ui/label"
import { PeopleService } from "@/services/people.service"
import { CategoriesService } from "@/services/categories.service"
import { TransactionsService } from "@/services/transactions.service"
import type {
    TransactionListItem,
    TransactionType,
    PaginatedTransactions,
    CreateTransactionInput,
} from "@/types/transaction"
import type { Category } from "@/types/category"
import type { Person } from "@/types/person"
import { Plus } from "lucide-react"

export default function Transactions() {
    const [transactionsPage, setTransactionsPage] = useState<PaginatedTransactions | null>(null)
    const [loading, setLoading] = useState(true)

    // create
    const [description, setDescription] = useState("")
    const [amount, setAmount] = useState<number | "">("")
    const [type, setType] = useState<TransactionType>("Expense")
    const [personId, setPersonId] = useState<number | "">("")
    const [categoryId, setCategoryId] = useState<number | "">("")

    // selects data
    const [people, setPeople] = useState<Person[]>([])
    const [categories, setCategories] = useState<Category[]>([])

    // pagination
    const [page, setPage] = useState(1)
    const [pageSize, setPageSize] = useState(10)

    async function loadPage(p = page, ps = pageSize) {
        try {
            setLoading(true)
            const data = await TransactionsService.get(p, ps)
            setTransactionsPage(data)
        } finally {
            setLoading(false)
        }
    }

    async function loadOptions() {
        const [ppl, cats] = await Promise.all([
            PeopleService.getAll(),
            CategoriesService.getAll(),
        ])
        setPeople(ppl)
        setCategories(cats)
    }

    useEffect(() => {
        loadOptions()
    }, [])

    useEffect(() => {
        loadPage(page, pageSize)
    }, [page, pageSize])

    function formatCurrency(value: number) {
        return new Intl.NumberFormat("pt-BR", { style: "currency", currency: "BRL" }).format(value)
    }

    function formatDate(iso?: string) {
        if (!iso) return "-"
        const d = new Date(iso)
        return d.toLocaleString("pt-BR", { dateStyle: "short", timeStyle: "short" })
    }

    async function handleCreate() {
        if (!description || !amount || !type || !personId || !categoryId) return
        const payload: CreateTransactionInput = {
            description,
            amount: Number(amount),
            type,
            personId: Number(personId),
            categoryId: Number(categoryId),
        }

        await TransactionsService.create(payload)

        setDescription("")
        setAmount("")
        setType("Expense")
        setPersonId("")
        setCategoryId("")
        setPage(1)
        await loadPage(1, pageSize)
    }

    const rows = useMemo(() => transactionsPage?.items ?? [], [transactionsPage])

    if (loading && !transactionsPage) {
        return <div className="text-muted-foreground">Loading transactions...</div>
    }

    return (
        <div className="space-y-6">
            <div className="flex items-center justify-between">
                <div className="flex items-center gap-3">
                    <h2 className="text-lg font-semibold">Transactions</h2>
                    <div className="text-sm text-muted-foreground">
                        {transactionsPage ? `${transactionsPage.totalItems} total` : ""}
                    </div>
                </div>

                <Dialog>
                    <DialogTrigger asChild>
                        <Button className="gap-2">
                            <Plus className="w-4 h-4" />
                            New transaction
                        </Button>
                    </DialogTrigger>

                    <DialogContent>
                        <DialogHeader>
                            <DialogTitle>New transaction</DialogTitle>
                        </DialogHeader>

                        <div className="space-y-4 mt-4">
                            <div className="space-y-2">
                                <Label>Description</Label>
                                <Input value={description} onChange={e => setDescription(e.target.value)} />
                            </div>

                            <div className="grid grid-cols-2 gap-3">
                                <div className="space-y-2">
                                    <Label>Amount</Label>
                                    <Input
                                        type="number"
                                        step="0.01"
                                        min="0"
                                        value={amount}
                                        onChange={e => setAmount(e.target.value === "" ? "" : Number(e.target.value))}
                                    />
                                </div>

                                <div className="space-y-2">
                                    <Label>Type</Label>
                                    <select
                                        value={type}
                                        onChange={e => setType(e.target.value as TransactionType)}
                                        className="w-full h-10 rounded-md border border-input bg-background px-3 text-sm"
                                    >
                                        <option value="Expense">Expense</option>
                                        <option value="Income">Income</option>
                                    </select>
                                </div>
                            </div>

                            <div className="grid grid-cols-2 gap-3">
                                <div className="space-y-2">
                                    <Label>Person</Label>
                                    <select
                                        value={personId}
                                        onChange={e => setPersonId(e.target.value === "" ? "" : Number(e.target.value))}
                                        className="w-full h-10 rounded-md border border-input bg-background px-3 text-sm"
                                    >
                                        <option value="">-- select person --</option>
                                        {people.map(p => (
                                            <option key={p.id} value={p.id}>
                                                {p.name}
                                            </option>
                                        ))}
                                    </select>
                                </div>

                                <div className="space-y-2">
                                    <Label>Category</Label>
                                    <select
                                        value={categoryId}
                                        onChange={e => setCategoryId(e.target.value === "" ? "" : Number(e.target.value))}
                                        className="w-full h-10 rounded-md border border-input bg-background px-3 text-sm"
                                    >
                                        <option value="">-- select category --</option>
                                        {categories.map(c => (
                                            <option key={c.id} value={c.id}>
                                                {c.description} ({c.purpose})
                                            </option>
                                        ))}
                                    </select>
                                </div>
                            </div>

                            <Button className="w-full mt-2" onClick={handleCreate}>
                                Create transaction
                            </Button>
                        </div>
                    </DialogContent>
                </Dialog>
            </div>


            <div className="rounded-lg border border-border overflow-hidden">
                <table className="w-full table-fixed">
                    <thead className="bg-muted/10 text-sm text-muted-foreground">
                        <tr>
                            <th className="p-3 text-left w-28">Date</th>
                            <th className="p-3 text-left">Description</th>
                            <th className="p-3 text-left w-36">Person</th>
                            <th className="p-3 text-left w-36">Category</th>
                            <th className="p-3 text-right w-28">Amount</th>
                            <th className="p-3 text-left w-24">Type</th>
                        </tr>
                    </thead>

                    <tbody>
                        {rows.length === 0 && (
                            <tr>
                                <td colSpan={6} className="p-4 text-center text-sm text-muted-foreground">
                                    No transactions yet
                                </td>
                            </tr>
                        )}

                        {rows.map((t: TransactionListItem) => {
                            const badgeClasses =
                                t.type === "Expense"
                                    ? "bg-destructive/10 text-destructive"
                                    : "bg-green-100 text-green-700"

                            return (
                                <tr key={t.id} className="border-t">
                                    <td className="p-3 align-top text-sm">{formatDate(t.createdAt)}</td>
                                    <td className="p-3 align-top">{t.description}</td>
                                    <td className="p-3 align-top text-sm">{t.person?.name ?? "-"}</td>
                                    <td className="p-3 align-top text-sm">{t.category?.description ?? "-"}</td>
                                    <td className="p-3 align-top text-right font-medium">{formatCurrency(t.amount)}</td>
                                    <td className="p-3 align-top">
                                        <span className={`inline-flex items-center px-2 py-0.5 rounded-full text-xs font-medium ${badgeClasses}`}>
                                            {t.type}
                                        </span>
                                    </td>
                                </tr>
                            )
                        })}
                    </tbody>
                </table>
            </div>

            <div className="flex items-center justify-between">
                <div className="flex items-center gap-2">
                    <Button
                        size="sm"
                        variant="outline"
                        onClick={() => setPage(p => Math.max(1, p - 1))}
                        disabled={!transactionsPage || transactionsPage.page <= 1}
                    >
                        Previous
                    </Button>

                    <Button
                        size="sm"
                        variant="outline"
                        onClick={() => setPage(p => (transactionsPage && p < transactionsPage.totalPages ? p + 1 : p))}
                        disabled={!transactionsPage || transactionsPage.page >= (transactionsPage?.totalPages ?? 1)}
                    >
                        Next
                    </Button>

                    <div className="text-sm text-muted-foreground ml-3">
                        Page {transactionsPage?.page ?? page} of {transactionsPage?.totalPages ?? "-"}
                    </div>
                </div>

                <div className="flex items-center gap-2">
                    <Label>Page size</Label>
                    <select
                        value={pageSize}
                        onChange={e => {
                            setPageSize(Number(e.target.value))
                            setPage(1)
                        }}
                        className="h-8 rounded-md border border-input bg-background px-2 text-sm"
                    >
                        <option value={5}>5</option>
                        <option value={10}>10</option>
                        <option value={25}>25</option>
                    </select>
                </div>
            </div>
        </div>
    )
}
