import { useEffect, useState } from "react"
import { Plus, Tag } from "lucide-react"
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
import type { Category, CategoryPurpose } from "@/types/category"
import { CategoriesService } from "@/services/categories.service"
import { toast } from "sonner"

export default function Categories() {
    const [categories, setCategories] = useState<Category[]>([])
    const [loading, setLoading] = useState(true)
    const [description, setDescription] = useState("")
    const [purpose, setPurpose] = useState<CategoryPurpose>("Expense")
    const [open, setOpen] = useState(false)


    async function loadCategories() {
        try {
            setLoading(true)
            const data = await CategoriesService.getAll()
            setCategories(data)
        } finally {
            setLoading(false)
        }
    }

    async function handleCreate() {
        await CategoriesService.create({ description, purpose })
        await loadCategories()

        setOpen(false)
        setDescription("")
        setPurpose("Expense")

        toast.success("Category created successfully")
    }

    useEffect(() => {
        loadCategories()
    }, [])

    if (loading) {
        return <div className="text-muted-foreground">Loading categories...</div>
    }

    return (
        <div className="space-y-6">
            <div className="flex items-center justify-between">
                <Dialog open={open} onOpenChange={setOpen}>
                    <DialogTrigger asChild>
                        <Button className="gap-2">
                            <Plus className="w-4 h-4" />
                            New category
                        </Button>
                    </DialogTrigger>

                    <DialogContent>
                        <DialogHeader>
                            <DialogTitle>New category</DialogTitle>
                        </DialogHeader>

                        <div className="space-y-4 mt-4">
                            <div className="space-y-2">
                                <Label>Description</Label>
                                <Input
                                    value={description}
                                    onChange={e => setDescription(e.target.value)}
                                />
                            </div>

                            <div className="space-y-2">
                                <Label>Purpose</Label>
                                <select
                                    value={purpose}
                                    onChange={e => setPurpose(e.target.value as CategoryPurpose)}
                                    className="w-full h-10 rounded-md border border-input bg-background px-3 text-sm"
                                >
                                    <option value="Expense">Expense</option>
                                    <option value="Income">Income</option>
                                    <option value="Both">Both</option>
                                </select>
                            </div>

                            <Button className="w-full mt-2" onClick={handleCreate}>
                                Create category
                            </Button>
                        </div>
                    </DialogContent>
                </Dialog>
            </div>

            <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
                {categories.map(category => (
                    <div
                        key={category.id}
                        className="bg-card border border-border rounded-xl p-4 shadow-sm flex items-start gap-3"
                    >
                        <div className="w-10 h-10 rounded-lg bg-primary/10 text-primary flex items-center justify-center">
                            <Tag className="w-5 h-5" />
                        </div>

                        <div>
                            <p className="font-medium">{category.description}</p>
                            <p className="text-sm text-muted-foreground">
                                {category.purpose}
                            </p>
                        </div>
                    </div>
                ))}
            </div>
        </div>
    )
}
